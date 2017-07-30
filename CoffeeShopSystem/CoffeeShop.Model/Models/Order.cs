using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int TableID { get; set; }

        public int PromotionID { get; set; }

        [Required]
        public int UserID { get; set; }

        public int ShopID { get; set; }
        public DateTime SetDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int Status { get; set; }
        public bool IsDelete { get; set; }

        [ForeignKey("TableID")]
        public virtual Table Table { get; set; }

        [ForeignKey("PromotionID")]
        public virtual Promotion Promotion { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("ShopID")]
        public virtual Shop Shop { get; set; }

        public virtual IEnumerable<OrderProduct> OrderProducts { get; set; }
    }
}