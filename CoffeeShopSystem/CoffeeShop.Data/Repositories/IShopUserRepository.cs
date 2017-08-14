using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoffeeShop.Data.Repositories
{
    public interface IShopUserRepository : IRepository<ShopUser>
    {
        IEnumerable<ShopUser> GetShopEmployee(Expression<Func<ShopUser, bool>> expression);
    }
}
