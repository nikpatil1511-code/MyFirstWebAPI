using Microsoft.EntityFrameworkCore;

namespace MyFirstWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}