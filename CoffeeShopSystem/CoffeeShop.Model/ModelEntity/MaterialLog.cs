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
    
    public partial class MaterialLog
    {
        public int ID { get; set; }
        public Nullable<int> MaterialID { get; set; }
        public Nullable<int> Inventory { get; set; }
        public string PreInventory { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual User User { get; set; }
    }
}
