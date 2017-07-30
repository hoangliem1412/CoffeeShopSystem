using CoffeeShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Required]
        public int CategoryID { get; set; }

        public int ShopID { get; set; }
        public decimal UnitPrice { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        public decimal Price { get; set; }
        public int? ViewCount { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

        [ForeignKey("ShopID")]
        public virtual Shop Shop { get; set; }
    }
}