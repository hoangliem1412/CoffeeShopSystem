using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Models
{
    [Table("Shops")]
    public class Shop
    {
        [Key]
        private int ID { set;  get;}
        [Required]

    }
}
