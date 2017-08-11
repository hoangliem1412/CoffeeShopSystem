using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Service
{
    public interface IUserService : IService<User>
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> SearchByPhone(string phoneFilter);
        User GetByID(int id);
    }
}
