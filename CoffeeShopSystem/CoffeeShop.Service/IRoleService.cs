using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public interface IRoleService : IService<Role>
    {
        IEnumerable<Role> GetAll();

        Role GetByID(int id);
        IEnumerable<Role> GetEmployeeRole();
    }
}
