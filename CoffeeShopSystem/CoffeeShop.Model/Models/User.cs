using CoffeeShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Models
{
    [Table("Users")]
    public class User : Auditable
    {
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName ="VARCHAR")]
        public string Password { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        public int WardID { get; set; }
        [MaxLength(256)]
        public string DetailAddress { get; set; }
        public DateTime Birthday { get; set; }
        [MaxLength(10)]
        public string Sex { get; set; }

        [ForeignKey("WardID")]
        public virtual Ward ward { get; set; }
    }
}
