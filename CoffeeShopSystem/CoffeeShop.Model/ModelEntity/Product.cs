namespace CoffeeShop.Model.ModelEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int ID { get; set; }

        public int ProductCategoryID { get; set; }

        public int? ShopID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        [Column(TypeName = "ntext")]
        public string Desciption { get; set; }

        public DateTime? StatDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Discount { get; set; }

        public bool? IsDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
