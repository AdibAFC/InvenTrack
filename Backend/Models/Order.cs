using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string CustomerName { get; set; } = "";

        [Column("OrderDate")]
        public DateTime OrderDate { get; set; }
        public float TotalAmount { get; set; }
        public string OrderStatus { get; set; } = "";

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
