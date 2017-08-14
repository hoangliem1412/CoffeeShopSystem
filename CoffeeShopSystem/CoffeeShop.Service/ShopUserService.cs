using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CoffeeShop.Service
{
    public class ShopUserService : Service<ShopUser>, IShopUserService
    {
        public ShopUserService(IRepository<ShopUser> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
        }
        
        public ShopUser Create(int shopID, int userID, int roleID, string description)
        {
            ShopUser shopUser = new ShopUser();
            shopUser.ShopID = shopID;
            shopUser.UserID = userID;
            shopUser.RoleID = roleID;
            shopUser.Description = description;
            shopUser.IsDelete = false;
            return shopUser; 
        }

        public IEnumerable<ShopUser> GetShopEmployee(int shopID)
        {

            return base.GetAll().Where(x => x.ShopID == shopID && (x.RoleID == 3 || x.RoleID == 5) && x.IsDelete != true);
        }
        public IEnumerable<ShopUser> GetShopEmployeeDeleted(int shopID)
        {

            return base.GetAll().Where(x => x.ShopID == shopID && (x.RoleID == 3 || x.RoleID == 5) && x.IsDelete == true);
        }

        public void Update(ShopUser group, int role, string roleDescription)
        {
            group.RoleID = role;
            group.Description = roleDescription;
            base.Update(group);
        }

        public void Delete(int shopUserID, bool b = true)
        {
            var su = base.GetSingleById(shopUserID);
            su.IsDelete = true;
            base.Update(su);
        }

        public dynamic Detail(int shopUserID)
        {
            var newSU = base.GetSingleById(shopUserID);
            var shopUser = new
            {
                ShopID=newSU.ShopID,
                ShopUserID = newSU.ID,
                UserID = newSU.UserID,
                RoleID = newSU.RoleID,
                RoleDescription=newSU.Description,
                Name = newSU.User.Name,
                Username = newSU.User.Username,
                Email = newSU.User.Email,
                Password=newSU.User.Password,
                DetailAddress = newSU.User.DetailAddress,
                City = newSU.User.Ward.District.City.ID,
                District = newSU.User.Ward.District.ID,
                Ward = newSU.User.Ward.ID,
                BirthDay= Convert.ToDateTime(newSU.User.BirthDay).ToString("yyyy-MM-dd"),
                Sex=newSU.User.Sex,
                UserDescription=newSU.User.Description,

            };
            return shopUser;
        }
    }
}