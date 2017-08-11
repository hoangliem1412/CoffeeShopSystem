using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using System;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class DistrictController : Controller
    {
        IDistrictService _iDistrictService;

        public DistrictController(IDistrictService iDis)
        {
            this._iDistrictService = iDis;
        }

        // GET: District
        public ActionResult Index()
        {
            var list = _iDistrictService.GetAll();
            return View(list);
        }

        //load data for datatables
        public ActionResult LoadData()
        {
            //dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            var data = _iDistrictService.GetAllIsDelete();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        //create partial list district
        public PartialViewResult PartialListDistrict()
        {
            var list = _iDistrictService.GetAllIsDelete();
            return PartialView("_PartialListDistrict", list);
        }

        [HttpPost]
        public JsonResult GetDistrictByCityID(int id)
        {
            var list = _iDistrictService.GetDistrictByCityID(id);
            //return new JsonResult { Data = list };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //insert district
        [HttpPost]
        public int Insert(District district)
        {
            try {
                _iDistrictService.Add(district);
                _iDistrictService.Save();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //update district
        [HttpPost]
        public int Update(District district)
        {
            try
            {
                _iDistrictService.Update(district);
                _iDistrictService.Save();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Delete district
        [HttpPost]
        public int Delete(int id)
        {
            try
            {
                _iDistrictService.Delete(id);
                _iDistrictService.Save();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //restore district
        [HttpPost]
        public int Restore(int id)
        {
            try
            {
                _iDistrictService.Restore(id);
                _iDistrictService.Save();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}