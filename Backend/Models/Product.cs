using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; } = "";
        public string Category { get; set; } = "";
        public int Quantity { get; set; }
        public float UnitePrice { get; set; }
        public int SupplierID { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
