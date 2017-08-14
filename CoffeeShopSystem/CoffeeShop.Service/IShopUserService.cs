using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public interface IShopUserService : IService<ShopUser>
    {
        ShopUser Create(int ShopID, int UserID, int RoleID, string Description);
        void Update(ShopUser group, int role, string roleDescription);
        IEnumerable<ShopUser> GetAll();
        ShopUser GetByID(int id);
        dynamic Detail(int shopUserID);
        IEnumerable<ShopUser> GetShopEmployee(int shopID);
        IEnumerable<ShopUser> GetShopEmployeeDeleted(int shopID);
        void Delete(int shopUserID, bool b = true);
    }
}
