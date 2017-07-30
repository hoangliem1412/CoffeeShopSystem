using CoffeeShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Model.Models
{
    [Table("ProductCategorys")]
    public class ProductCategory : Auditable
    {
        public virtual IEnumerable<Product> Products { get; set; }
    }
}