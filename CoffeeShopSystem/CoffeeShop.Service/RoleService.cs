using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    

    public class RoleService : Service<Role>, IRoleService
    {
        private IRoleRepository _RoleRepository;
        private IUnitOfWork _unitOfWork;

        public RoleService(IRepository<Role> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
           
        }        

        public IEnumerable<Role> GetEmployeeRole()
        {
            return _RoleRepository.GetEmployeeRole(x => x.ID == 3 || x.ID==5);
        }
    }
}
