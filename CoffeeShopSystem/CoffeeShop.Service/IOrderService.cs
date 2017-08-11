using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public interface IOrderService
    {
        void Update(Order table);
        void Delete(int id);
        IEnumerable<Order> GetAll();
        Order GetByID(int id);
        void Save();
        dynamic SearchByIDandTable(string keyword, List<Order> lst);
        dynamic GetByStatus(string status,ref List<Order> lst);
    }
}
