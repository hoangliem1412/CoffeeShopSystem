using CoffeeShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Models
{
    public class City : Auditable
    {
        public virtual IEnumerable<District> Districts { get; set; }
    }
}
