namespace CoffeeShop.Model.ModelEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int ID { get; set; }

        public int TableID { get; set; }

        public int? PromotionID { get; set; }

        public int UserID { get; set; }

        public DateTime? SetDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalMoney { get; set; }

        public bool? Status { get; set; }

        public bool? isDelete { get; set; }

        public int ShopID { get; set; }

        public virtual Promotion Promotion { get; set; }

        public virtual Table Table { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
