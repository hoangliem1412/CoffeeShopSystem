using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using CoffeeShop.Web.Models;
using System;
using System.Linq;
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
            var list = _iWardService.GetAll().Select(x => new WardViewModel { ID = x.ID, Name = x.Name, Description = x.Description, DistrictID = x.DistrictID, NameDistrict = x.District.Name, IsDelete = x.IsDelete });
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        //insert ward
        [HttpPost]
        public int Insert(Ward ward)
        {
            try
            {
                int rs = _iWardService.Insert(ward);
                _iWardService.Save();
                return rs;
            }
            catch
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
                int rs = _iWardService.Edit(ward);
                if (rs == 1)
                {
                    _iWardService.Save();
                }
                return rs;
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
                _iWardService.Delete1(id);
                _iWardService.Save();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Restore district
        [HttpPost]
        public int Restore(int id)
        {
            try
            {
                _iWardService.Restore(id);
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