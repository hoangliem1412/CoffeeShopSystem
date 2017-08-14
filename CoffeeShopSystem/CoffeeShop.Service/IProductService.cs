using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public interface IProductService : IService<Product>
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllPaging(int pageIndex, int pageSize, out int totalRow);        
        Product GetByID(int ID);
    }
}
