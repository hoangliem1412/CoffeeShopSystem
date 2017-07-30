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
    [Table("Materials")]
    public class Material : Auditable
    {
        public int CategogyID { get; set; }
        [MaxLength(256)]
        public string UnitName { get; set; }

        [ForeignKey("CategogyID")]
        public virtual MaterialCategogy MaterialCategogy { get; set; }
        public virtual IEnumerable<MaterialOrderDetail> MaterialOrderDetails { get; set; }

    }
}
