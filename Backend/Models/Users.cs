using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Role { get; set; } = "";
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }=DateTime.Now;
    }
}
