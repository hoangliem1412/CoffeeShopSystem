//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeShop.Model.ModelEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.MaterialLogs = new HashSet<MaterialLog>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string UnitName { get; set; }
        public Nullable<int> Inventory { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual MaterialCategory MaterialCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialLog> MaterialLogs { get; set; }
    }
}
