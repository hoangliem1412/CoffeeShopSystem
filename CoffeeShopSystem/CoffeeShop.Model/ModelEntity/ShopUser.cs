namespace CoffeeShop.Model.ModelEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopUser")]
    public partial class ShopUser
    {
        public int ID { get; set; }

        public int? ShopID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public bool? IsDelete { get; set; }

        public virtual Role Role { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual User User { get; set; }
    }
}
