namespace CoffeeShop.Model.ModelEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialLog")]
    public partial class MaterialLog
    {
        public int ID { get; set; }

        public int? MaterialID { get; set; }

        public int? Inventory { get; set; }

        [StringLength(10)]
        public string PreInventory { get; set; }

        public int? EmployeeID { get; set; }

        public string Description { get; set; }

        public bool? IsDelete { get; set; }

        public virtual Material Material { get; set; }

        public virtual User User { get; set; }
    }
}
