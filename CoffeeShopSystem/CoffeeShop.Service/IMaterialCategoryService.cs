using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public interface IMaterialCategoryService
    {
        IEnumerable<MaterialCategory> GetAll();
    }
}
