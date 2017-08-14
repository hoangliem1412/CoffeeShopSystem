using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoffeeShop.Data.Repositories
{
    public class ShopUserRepository : RepositoryBase<ShopUser>, IShopUserRepository
    {
        public ShopUserRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<ShopUser> GetShopEmployee(Expression<Func<ShopUser, bool>> expression)
        {
            return GetMany(expression);
        }
    }
}
