using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Web.Models
{
    public class MaterialCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        
        public virtual ICollection<MaterialViewModel> Materials { get; set; }
        
        public virtual ICollection<MaterialLogViewModel> MaterialLogs { get; set; }
    }
}