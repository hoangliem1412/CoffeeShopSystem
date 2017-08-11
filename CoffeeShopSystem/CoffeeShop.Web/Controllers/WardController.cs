using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using System;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class WardController : Controller
    {
        IWardService _iWardService;

        public WardController(IWardService iWard)
        {
            this._iWardService = iWard;
        }

        // GET: Ward
        public ActionResult Index()
        {
            var list = _iWardService.GetAll();
            return View(list);
        }

        //load data for datatables
        public ActionResult LoadData()
        {
            //dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            var data = _iWardService.GetAllActive();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        //insert ward
        [HttpPost]
        public int Insert(Ward ward)
        {
            try
            {
                _iWardService.Add(ward);
                _iWardService.Save();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //update district
        [HttpPost]
        public int Update(Ward ward)
        {
            try
            {
                _iWardService.Update(ward);
                _iWardService.Save();
                return 1;
            }
            catch (Exception ex)
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
                _iWardService.Delete(id);
                _iWardService.Save();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}