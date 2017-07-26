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
    [Table("Wards")]
    public class Ward : Auditable
    {
        [Required]
        public int DistrictID { get; set; }

        [ForeignKey("DistrictID")]
        public virtual District District { get; set; }
    }
}
