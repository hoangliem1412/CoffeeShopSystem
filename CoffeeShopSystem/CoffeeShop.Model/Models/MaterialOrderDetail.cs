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
    [Table("MaterialOrderDetails")]
    public class MaterialOrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int MaterialID { get; set; }
        public int Quanlity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }

        [ForeignKey("MaterialID")]
        public virtual Material Material { get; set; }
        [ForeignKey("OrderID")]
        public virtual MaterialOrder MaterialOrder { get; set; }
    }
}
