using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public interface IUserService : IService<User>
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> SearchByPhone(string phoneFilter);
        User GetByID(int id);
    }
}
