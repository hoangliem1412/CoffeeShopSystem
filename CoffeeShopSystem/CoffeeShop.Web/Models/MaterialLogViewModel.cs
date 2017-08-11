using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Web.Models
{
    public class MaterialLogViewModel
    {
        public int ID { get; set; }
        public Nullable<int> MaterialID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> Inventory { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<bool> Type { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        public virtual MaterialCategoryViewModel MaterialCategory { get; set; }
        //public virtual User User { get; set; }
        public virtual MaterialViewModel Material { get; set; }
    }
}