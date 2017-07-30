using CoffeeShop.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Model.Models
{
    [Table("Promotions")]
    public class Promotion : Auditable
    {
        public int ShopID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal BasePurchase { get; set; }
        public decimal Discount { get; set; }

        [ForeignKey("ShopID")]
        public virtual Shop Shop { get; set; }
    }
}