namespace CoffeeShop.Model.ModelEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Material")]
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            MaterialLogs = new HashSet<MaterialLog>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(255)]
        public string UnitName { get; set; }

        public int? Inventory { get; set; }

        public string Description { get; set; }

        public bool? IsDelete { get; set; }

        public virtual MaterialCategory MaterialCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialLog> MaterialLogs { get; set; }
    }
}
