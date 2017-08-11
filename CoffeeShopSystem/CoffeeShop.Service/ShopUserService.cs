using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System;

namespace CoffeeShop.Service
{
    public class ShopUserService : Service<ShopUser>, IShopUserService
    {
        private IShopUserRepository _ShopUserRepository;
        private IUnitOfWork _unitOfWork;

        public ShopUserService(IRepository<ShopUser> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
        }
        
        public ShopUser Create(int ShopID, int UserID, int RoleID, string Description)
        {
            return _ShopUserRepository.Create(ShopID, UserID, RoleID, Description);
        }

        public IEnumerable<ShopUser> GetShopEmployee(int shopID)
        {

            return _ShopUserRepository.GetShopEmployee(x => x.ShopID == shopID && (x.RoleID == 3 || x.RoleID == 5) && x.IsDelete != true);
        }
        
        public void Update(ShopUser group, int role, string roleDescription)
        {
            group.RoleID = role;
            group.Description = roleDescription;
            _ShopUserRepository.Update(group);
        }

        public void Delete(int shopUserID, bool b = true)
        {
            var su = _ShopUserRepository.GetSingleById(shopUserID);
            su.IsDelete = true;
            _ShopUserRepository.Update(su);
        }

        public dynamic Detail(int shopUserID)
        {
            var newSU = _ShopUserRepository.GetSingleById(shopUserID);
            var su = new
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
            return su;
        }
    }
}