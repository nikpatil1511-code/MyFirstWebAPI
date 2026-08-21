using Microsoft.EntityFrameworkCore;
using MyFirstWebAPI.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // include XML comments (if generated)
    var xmlFile = System.IO.Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, ".xml");
    if (System.IO.File.Exists(xmlFile)) c.IncludeXmlComments(xmlFile);
});

builder.Services.AddControllers();

// register DbContext (SQLite) and EF Core repository
//var conn = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=products.db";
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(conn));
//builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=students.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFirstWebAPI v1");
    c.RoutePrefix = "swagger"; // Swagger UI at /swagger
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// ensure database created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

app.Run();
