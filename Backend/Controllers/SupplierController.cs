using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuppliersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin & Manager: Add a supplier
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult AddSupplier([FromBody] Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return Ok(new { Message = "Supplier added successfully!" });
        }

        // All roles: Get a list of suppliers
        [HttpGet]
        [Authorize]
        public IActionResult GetSuppliers()
        {
            var suppliers = _context.Suppliers.ToList();
            return Ok(suppliers);
        }
    }
}
