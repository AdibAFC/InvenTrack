using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class InventoryTransaction
    {
        [Key]
        public int TransactionID { get; set; } // This will be the primary key
        public int ProductID { get; set; }
        public string TransactionType { get; set; } = "";
        public int Quantity { get; set; }

        [Column("TransactionDate")]
        public DateTime TransactionDate { get; set; }
        public int UserID { get; set; }
        public string Notes { get; set; } = "";
    }
}
