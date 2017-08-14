using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Service
{
    

    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService(IRepository<Role> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
           
        }        

        public IEnumerable<Role> GetEmployeeRole()
        {
            return base.GetAll().Where(x => x.ID == 3 || x.ID==5);
        }
    }
}
