using CoffeeShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Models
{
    [Table("Roles")]
    public class Role : Auditable
    {
        public virtual IEnumerable<ShopUser> ShopUsers { get; set; }
    }
}
