using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{


    public class UserService : Service<User>, IUserService
    {
        public UserService(IRepository<User> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
        }

        public IEnumerable<User> SearchByPhone(string phoneFilter)
        {
            if (phoneFilter == "")
            {
                return base.GetAll();
            }
            return base.GetMulti(u => u.Name == phoneFilter);
        }
    }
}
