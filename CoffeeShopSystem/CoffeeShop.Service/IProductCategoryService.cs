using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public interface IProductCategoryService : IService<ProductCategory>
    {
        IEnumerable<ProductCategory> GetAll();

        ProductCategory GetByID(int id);
    }
}
