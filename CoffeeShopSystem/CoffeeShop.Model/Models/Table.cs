using CoffeeShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Models
{
    [Table("Tables")]
    public class Table : Auditable
    {
        
        public int GroupTableId { get; set; }
        public int ShopId { get; set; }

        [ForeignKey("GroupTableID")]
        public virtual GroupTable GroupTable { get; set; }
    }
}
