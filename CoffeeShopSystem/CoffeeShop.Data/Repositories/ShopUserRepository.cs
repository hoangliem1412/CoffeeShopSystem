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
        public ShopUser Create(int ShopID, int UserID, int RoleID, string Description)
        {
            ShopUser su = new ShopUser();
            su.ShopID = ShopID;
            su.UserID = UserID;
            su.RoleID = RoleID;
            su.Description = Description;
            su.IsDelete = false;
            return su;
        }
        //public ShopUser Detail(int shopUserID)
        //{
        //    return GetSingleById(shopUserID);
        //}
    }
}
