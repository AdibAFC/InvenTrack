using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin & Manager: Add or Edit a product
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult AddOrEditProduct([FromBody] Product product)
        {
            if (product.ProductID == 0)
                _context.Products.Add(product);
            else
                _context.Products.Update(product);

            _context.SaveChanges();
            return Ok(new { Message = "Product saved successfully!" });
        }

        // All roles: Get a list of products
        [HttpGet]
        [Authorize]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
    }
}
