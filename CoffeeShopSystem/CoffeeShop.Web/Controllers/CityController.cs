using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class CityController : Controller
    {

        ICityService _iCityService;
        public CityController(ICityService cityService)
        {
            this._iCityService = cityService;
        }

        // GET: City
        public ActionResult Index()
        {
            var list = _iCityService.GetAll();
            return View(list);
        }

        //load data for datatables
        public ActionResult LoadData()
        {
            var list = _iCityService.GetAll().Select(x => new City { ID = x.ID, Name = x.Name, Description = x.Description, IsDelete = x.IsDelete });
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        //create partial list city
        public PartialViewResult PartialListCity()
        {
            var list = _iCityService.GetAllIsDelete();
            return PartialView("_PartialListCity", list);

        }

        //insert cty
        [HttpPost]
        public int Insert(City city)
        {
            try
            {
                return _iCityService.Insert(city);
            }
            catch
            {
                return 0;
            }
        }

        //update city
        [HttpPost]
        public int Update(City city)
        {
            try
            {
                int rs = _iCityService.Edit(city);
                if (rs == 1)
                {
                    _iCityService.Save();
                }
                return rs;
            }
            catch
            {
                return 0;
            }
        }

        //Delete city
        [HttpPost]
        public int Delete(int id)
        {
            try
            {
                _iCityService.Delete1(id);
                _iCityService.Save();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //restore city
        [HttpPost]
        public int Restore(int id)
        {
            try
            {
                _iCityService.Restore(id);
                _iCityService.Save();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}