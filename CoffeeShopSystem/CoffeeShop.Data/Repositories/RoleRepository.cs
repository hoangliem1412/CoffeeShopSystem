using System;
using System.Collections.Generic;
using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System.Linq.Expressions;

namespace CoffeeShop.Data.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Role> GetEmployeeRole(Expression<Func<Role, bool>> expression)
        {
            return GetMany(expression);
        }
    }
}