using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
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
            //dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            var data = _iCityService.GetAllIsDelete();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
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
                _iCityService.Add(city);
                _iCityService.Save();
                return 1;
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
                _iCityService.Update(city);
                _iCityService.Save();
                return 1;
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
                _iCityService.Delete(id);
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