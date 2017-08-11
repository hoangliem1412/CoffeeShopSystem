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
        ShopUser Create(int ShopID, int UserID, int RoleID, string Description);
        //ShopUser Detail(int shopUserID);
    }
}
