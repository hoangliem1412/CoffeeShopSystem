using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Service
{
    public interface IOrderService
    {
        void Add(Order table);
        void Update(Order table);
        void Delete(int id);
        IEnumerable<Order> GetAll();
        Order GetByID(int id);
        void Save();
    }
}
