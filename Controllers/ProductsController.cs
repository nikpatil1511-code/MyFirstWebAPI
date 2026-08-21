using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstWebAPI.Data;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;

        }

        //getapi student

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var product = await _db.Products.ToListAsync();
            if (product == null)
            {
                return NotFound("product not found");

            }
            return Ok(product);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }



        [HttpPut("{id}")]

        public async Task<IActionResult> Update (int id, [FromBody] Product product)
        {
            if (id !=product.Id)
            {
                return BadRequest("product not found");

            }
            var exists = await _db.Products.AnyAsync(p => p.Id == id);
            if (!exists)
            {
                return BadRequest("product not found");

            }

            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteById(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound("product not found");

            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return NoContent();
        }


//        private static List<Product> products = new List<Product>()
//            {
//                new Product { Id = 1, Name = "Laptop", Price = 1000 },
//                new Product { Id = 2, Name = "Mouse", Price = 2000 },
//                new Product { Id = 3, Name = "KeyBoard", Price = 3000 },
//                new Product { Id = 4, Name = "Wirless mouse", Price = 5000 }p
//        [HttpGet]
//        public IActionResult GetAllProducts()
//        {

//            return Ok(products);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetProductById(int id)
//        {

//            var product = products.FirstOrDefault(p => p.Id == id);

//            if (product == null)
//            {
//                return NotFound("Product not found!");
//            }

//            return Ok(product);
//        }
//        [HttpPost]
//        public IActionResult AddProduct(Product newProduct)
//        {
//            products.Add(newProduct);
//            return Ok("Product added: " + newProduct.Name + ", Price: " + newProduct.Price);
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateProduct(int id, Product updateProduct)
//        {

//            var product = products.FirstOrDefault(p => p.Id == id);
//            if (product == null)
//            {
//                return NotFound("Product Not Found");

//            }
//            product.Name = updateProduct.Name;
//            product.Price = updateProduct.Price;
//            return Ok("Product Updated" + product.Name + ",price:" + product.Price);
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteProduct(int id)
//        {
//            var product = products.FirstOrDefault(p => p.Id == id);
//            if (product == null)
//            {
//                return NotFound("Product not FOund");

//            }

//            products.Remove(product);
//            return Ok("Product Deleted:" +product.Name);

//        }
}
}