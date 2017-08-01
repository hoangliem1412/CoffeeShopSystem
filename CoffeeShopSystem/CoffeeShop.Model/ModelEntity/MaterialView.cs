namespace CoffeeShop.Model.ModelEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialView")]
    public partial class MaterialView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Name { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(255)]
        public string UnitName { get; set; }

        public int? Inventory { get; set; }

        public string Description { get; set; }

        public bool? IsDelete { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string CategoryName { get; set; }
    }
}
