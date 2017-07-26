using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Abstract
{
    public interface IAuditable
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool IsDelete { get; set; }
    }
}
