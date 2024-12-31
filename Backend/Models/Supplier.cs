using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Supplier
    {
        [Key]
        public int SuppplierID { get; set; }
        public string SupplierName { get; set; } = "";
        public string ContactNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
