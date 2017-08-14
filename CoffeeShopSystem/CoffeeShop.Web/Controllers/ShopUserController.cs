using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using System.Linq;
using System.Web.Mvc;


namespace CoffeeShop.Web.Controllers
{
    public class ShopUserController : Controller
    {
        //initialize service object
        IShopUserService shopUserService;
        ICityService cityService;
        IDistrictService districtService;
        IWardService wardService;
        IRoleService roleService;
        IUserService userService;

        public ShopUserController(IShopUserService ShopUserService, ICityService CityService, IDistrictService DistrictService, IWardService WardService, IRoleService RoleService, IUserService UserService)
        {
            this.shopUserService = ShopUserService;
            this.cityService = CityService;
            this.districtService = DistrictService;
            this.wardService = WardService;
            this.roleService = RoleService;
            this.userService = UserService;
        }
        
        /// <summary>
        /// GET:Detail
        /// </summary>
        /// <param name="shopUserID"></param>
        /// <returns>ShopUser</returns>
        public JsonResult Detail(int shopUserID)
        {
            var shopUser = shopUserService.Detail(shopUserID);
            return Json(shopUser, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// GET: ShopUser
        /// </summary>
        /// <returns>List<ShopUser></ShopUser></returns>
        public ActionResult Index()
        {
            var employee = shopUserService.GetShopEmployee((int)shopUserService.GetByID(3).ShopID).ToList();
            ViewBag.CityList = cityService.GetAll().ToList();
            ViewBag.RoleList = roleService.GetEmployeeRole().ToList();
            return View(employee);
        }
        /// <summary>
        /// GET: List of district by city
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns>List<District></returns>
        public JsonResult DistrictListByCityID(int cityID)
        {
            var districtList = districtService.GetByCityID(cityID).Select(x => new { ID = x.ID, Name = x.Name }).ToList();
            return Json(districtList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WardListByDistrictID(int districtID)
        {
            var districtList = wardService.GetByDistrictID(districtID).Select(x => new { ID = x.ID, Name = x.Name }).ToList();
            return Json(districtList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// POST-Add new suer-shopuser
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <param name="roleDescription"></param>
        /// <returns>ShopUser-Added</returns>
        [HttpPost]
        public JsonResult Add(User user, int role, string roleDescription)
        {
            userService.Add(user);
            userService.Save();
            ShopUser shopUser = new ShopUser();
            shopUser = shopUserService.Create((int)shopUserService.GetByID(3).ShopID, user.ID, role, roleDescription);
            shopUserService.Add(shopUser);
            shopUserService.Save();

            var ward = wardService.GetByID((int)user.WardID);
            var district = districtService.GetByID(ward.DistrictID);
            var city = cityService.GetByID(district.CityID);
            var data = new
            {
                ID = shopUser.ID,
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                DetailAddress = user.DetailAddress,
                City = city.Name,
                District = district.Name,
                Ward = ward.Name
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// POST-Delete
        /// </summary>
        /// <param name="shopUserID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int shopUserID)
        {
            shopUserService.Delete(shopUserID, true);
            shopUserService.Save();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Post:Edit ShopUser
        /// </summary>
        /// <param name="u"></param>
        /// <param name="role"></param>
        /// <param name="roleDescription"></param>
        /// <param name="shopUserID"></param>
        /// <returns>ShopUser-editted</returns>
        [HttpPost]
        public JsonResult Edit(User u, int role, string roleDescription, int shopUserID)
        {
            userService.Update(u);
            var shopUser = shopUserService.GetByID(shopUserID);
            shopUserService.Update(shopUser, role, roleDescription);
            userService.Save();
            shopUserService.Save();

            var ward = wardService.GetByID((int)u.WardID);
            var district = districtService.GetByID(ward.DistrictID);
            var city = cityService.GetByID(district.CityID);
            var data = new
            {
                ID = shopUser.ID,
                Name = u.Name,
                Username = u.Username,
                Email = u.Email,
                DetailAddress = u.DetailAddress,
                City = city.Name,
                District = district.Name,
                Ward = ward.Name
            }; ;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// GET:Deleted Employee
        /// </summary>
        /// <returns>List<ShopUser>-Deleted</returns>
        //
        public JsonResult ViewDeleted()
        {
            var data = shopUserService.GetShopEmployeeDeleted((int)shopUserService.GetByID(3).ShopID)
                .Select(x => new {
                    ID = x.ID,
                    Name = x.User.Name,
                    Username = x.User.Username,
                    Email = x.User.Email,
                    DetailAddress = x.User.DetailAddress,
                    City = x.User.Ward.District.City.Name,
                    District = x.User.Ward.District.Name,
                    Ward = x.User.Ward.Name
                }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// GET:Current Employee
        /// </summary>
        /// <returns>List<ShopUser>-Managed</returns>
        //
        public JsonResult ViewCurrent()
        {
            var data = shopUserService.GetShopEmployee((int)shopUserService.GetByID(3).ShopID)
                .Select(x => new {
                    ID = x.ID,
                    Name = x.User.Name,
                    Username = x.User.Username,
                    Email = x.User.Email,
                    DetailAddress = x.User.DetailAddress,
                    City = x.User.Ward.District.City.Name,
                    District = x.User.Ward.District.Name,
                    Ward = x.User.Ward.Name
                }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Check Username Is Unique
        /// </summary>
        /// <param name="input"></param>
        /// <param name="userID"></param>
        /// <returns>bool</returns>
        [HttpPost]
        public bool IsUsernameUnique(string input, int? userID)
        {
            bool check = true;
            var model = userService.GetAll()
                .Where(x => x.Username == input && x.IsDelete == false).FirstOrDefault();
            var comparator = userService.GetAll()
                .Where(x => x.Username == input && x.ID != userID && x.IsDelete == false).FirstOrDefault();
            if (userID.HasValue == false || userID == 0)
            {
                if (model != null)
                {
                    check = false;
                }
                else
                {
                    //do nothing
                }
            }
            else
            {
                if (comparator != null)
                {
                    check = false;
                }
                else
                {
                    //do nothing
                }
            }
            return check;
        }
        /// <summary>
        /// Check Username Is Unique
        /// </summary>
        /// <param name="input"></param>
        /// <param name="userID"></param>
        /// <returns>bool</returns>
        [HttpPost]
        public bool IsEmailUnique(string input, int? userID)
        {
            bool check = true;
            var model = userService.GetAll()
                .Where(x => x.Email == input && x.IsDelete == false).FirstOrDefault();
            var comparator = userService.GetAll()
                .Where(x => x.Username == input && x.ID != userID && x.IsDelete == false).FirstOrDefault();
            if (userID.HasValue == false || userID == 0)
            {
                if (model != null)
                {
                    check = false;
                }
                else
                {
                    //do nothing
                }
            }
            else
            {
                if (comparator != null)
                {
                    check = false;
                }
                else
                {
                    //do nothing
                }
            }
            return check;
        }
    }
}