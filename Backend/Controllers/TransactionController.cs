using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // All roles: Record a transaction
        [HttpPost]
        [Authorize]
        public IActionResult RecordTransaction([FromBody] InventoryTransaction transaction)
        {
            _context.InventoryTransactions.Add(transaction);
            _context.SaveChanges();
            return Ok(new { Message = "Transaction recorded successfully!" });
        }

        // Admin & Manager: View transactions
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult GetTransactions()
        {
            var transactions = _context.InventoryTransactions.ToList();
            return Ok(transactions);
        }
    }
}
