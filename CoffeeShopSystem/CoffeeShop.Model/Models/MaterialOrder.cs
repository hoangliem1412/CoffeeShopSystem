using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Models
{
    [Table("MaterialOrders")]
    public class MaterialOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Discount { get; set; }
        public int Vat { get; set; }
        [Column(TypeName =("decimal(18, 0)"))]
        public decimal Amount { get; set; }
        [Column(TypeName = ("decimal(18, 0)"))]
        public decimal Charge { get; set; }
        public int EmployeeID { get; set; }
        public bool IsPaid { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual User User { get; set; }
    }
}
