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

        public ShopUserController(IShopUserService ShopUserService,ICityService CityService, IDistrictService DistrictService, IWardService WardService, IRoleService RoleService, IUserService UserService)
        {
            this.shopUserService = ShopUserService;
            this.cityService = CityService;
            this.districtService = DistrictService;
            this.wardService = WardService;
            this.roleService = RoleService;
            this.userService = UserService;
        }

        //
        //GET:Detail
        public JsonResult Detail(int shopUserID)
        {
            var su = shopUserService.Detail(shopUserID);
            return Json(su, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: ShopUser
        public ActionResult Index()
        {
            var employee = shopUserService.GetShopEmployee((int)shopUserService.GetByID(3).ShopID).ToList();
            ViewBag.CityList = cityService.GetAll().ToList();
            //ViewBag.DistrictList = districtService.GetByCityID(1).ToList();
            //ViewBag.WardList = wardService.GetByDistrictID(1).ToList();
            ViewBag.RoleList = roleService.GetEmployeeRole().ToList();
            return View(employee);
        }
        public JsonResult DistrictListByCityID(int cityID)
        {
            var districtList=districtService.GetByCityID(cityID).Select(x => new { ID = x.ID, Name = x.Name }).ToList();
            
            return Json(districtList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WardListByDistrictID(int districtID)
        {
            var districtList = wardService.GetByDistrictID(districtID).Select(x => new { ID = x.ID, Name = x.Name }).ToList();

            return Json(districtList, JsonRequestBehavior.AllowGet);
        }

        //
        //Post:Add User-ShopUser
        [HttpPost]
        public JsonResult Add(User u,int role,string roleDescription)
        {
            userService.Add(u);
            userService.Save();
            var ward = wardService.GetByID((int)u.WardID);
            var district = districtService.GetByID(ward.DistrictID);
            var city = cityService.GetByID(district.CityID);
            ShopUser su = new ShopUser();
            su = shopUserService.Create((int)shopUserService.GetByID(3).ShopID, u.ID, role, roleDescription);
            shopUserService.Add(su);
            shopUserService.Save();

            //var employee = shopUserService.GetShopEmployee((int)shopUserService.GetByID(3).ShopID)
            //    .Select(x => new { ID = x.ID, Name = x.User.Name, Username = x.User.Username, Email = x.User.Email, DetailAddress=x.User.DetailAddress ,
            //        City =x.User.Ward.District.City.Name , District=x.User.Ward.District.Name , Ward=x.User.Ward.Name }).ToList();
            var data=new { ID = su.ID, Name = u.Name, Username = u.Username, Email =u.Email, DetailAddress=u.DetailAddress ,
                    City =city.Name , District=district.Name , Ward=ward.Name };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //
        //Post:Delete ShopUser
        [HttpPost]
        public JsonResult Delete(int shopUserID)
        {
            shopUserService.Delete(shopUserID,true);
            shopUserService.Save();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        //
        //Post:Edit ShopUser
        [HttpPost]
        public JsonResult Edit(User u, int role, string roleDescription,int shopUserID)
        {
            userService.Update(u);
            var ward = wardService.GetByID((int)u.WardID);
            var district = districtService.GetByID(ward.DistrictID);
            var city = cityService.GetByID(district.CityID);
            var su = shopUserService.GetByID(shopUserID);
            shopUserService.Update(su, role, roleDescription);
            userService.Save();
            shopUserService.Save();
            //var employee = shopUserService.GetShopEmployee((int)shopUserService.GetByID(3).ShopID)
            //    .Select(x => new { ID = x.ID, Name = x.User.Name, Username = x.User.Username, Email = x.User.Email, DetailAddress=x.User.DetailAddress ,
            //        City =x.User.Ward.District.City.Name , District=x.User.Ward.District.Name , Ward=x.User.Ward.Name }).ToList();
            var data=new { ID = su.ID, Name = u.Name, Username = u.Username, Email =u.Email, DetailAddress=u.DetailAddress ,
                    City =city.Name , District=district.Name , Ward=ward.Name }; ;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}