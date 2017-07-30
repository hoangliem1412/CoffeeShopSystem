using CoffeeShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Models
{
    [Table("MaterialCategogys")]
    public class MaterialCategogy : Auditable
    {
        public virtual IEnumerable<Material> Materials { get; set; }
    }
}
