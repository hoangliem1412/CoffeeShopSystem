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
    [Table("ShopUsers")]
    public class ShopUser : Auditable
    {
        [Required]
        public int ShopID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int RoleID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
    }
}
