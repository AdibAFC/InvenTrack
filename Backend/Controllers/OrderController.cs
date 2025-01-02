using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin & Manager: Process a new order
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(new { Message = "Order created successfully!" });
        }

        // Admin & Manager: Get all orders
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult GetOrders()
        {
            var orders = _context.Orders.ToList();
            return Ok(orders);
        }
    }
}
