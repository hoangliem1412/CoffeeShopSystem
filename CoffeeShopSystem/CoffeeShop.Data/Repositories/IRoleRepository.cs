using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoffeeShop.Data.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetEmployeeRole(Expression<Func<Role, bool>> expression);
    }
}
