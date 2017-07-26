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
    [Table("Districts")]
    public class District : Auditable
    {
        [Required]
        public int CityID { get; set; }

        [ForeignKey("CityID")]
        public virtual City City { get; set; }
        public virtual IEnumerable<Ward> Wards { get; set; }
    }
}
