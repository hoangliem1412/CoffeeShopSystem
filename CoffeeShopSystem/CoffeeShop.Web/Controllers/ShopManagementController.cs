﻿using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class ShopManagementController : Controller
    {
        // GET: Shop

        IShopService _shopService;
        IDistrictService _districtService;
        IWardService _wardService;
        ICityService _cityService;

        public ShopManagementController(IShopService shopService, IDistrictService districtService, IWardService wardService, ICityService cityService)
        {
            _shopService = shopService;
            _districtService = districtService;
            _wardService = wardService;
            _cityService = cityService;
            
        }
        


        



        // GET: AccountManagement
        //sort by {ID,Name} ; type by  {asc ,desc};
        public ActionResult Index(string sort ="ID", string type="asc", int curPage = 1, int pageSize =5, string option = "Managing")
        {

           
            int total;
            ViewBag.IDType = _shopService.ChangeSortType(type, sort == "ID");
            ViewBag.NameType = _shopService.ChangeSortType(type, sort == "Name");
            
            ViewBag.Sort = sort;
            ViewBag.MyStyle = type;
            ViewBag.Option = option;

            List<Shop> lstShop;
            if (option == "Managing")
            {
                lstShop = _shopService.GetAllNonDeleteWithPaginationAndSort(sort, type, out total, curPage, pageSize).ToList();
                total = _shopService.GetAllNonDelete().Count();
            }

            else // Deleted
            {
                lstShop = _shopService.GetAllDeletedWithPaginationAndSort(sort, type, out total, curPage, pageSize).ToList();
                total = _shopService.GetAllDeleted().Count();
            }
            int nPages = total / pageSize;

            if (total % pageSize > 0) 
            {
                nPages++;
            }

                ViewBag.Pages = nPages;

               

                ViewBag.curPage = curPage;
                ViewBag.NextPage = curPage + 1;
                ViewBag.PrevPage = curPage - 1;

              

                 return View(lstShop.ToList());


        }


        public ActionResult CreateNew()
        {
           
            return View();


        }

        [HttpPost]
        public ActionResult CreateNew(Shop s)
        {
            
            bool result = _shopService.CreateNew(s);
            if (result)
            {
                return RedirectToAction("Index", "ShopManagement", new { result = "AddSuccess" });
            }

            return RedirectToAction("Index", "ShopManagement", new { result = "AddFailed" });
        }

        public ActionResult Edit(int id)
        {
           
            //check if that id exist in db
           
            Shop s = _shopService.GetShopByID(id);
            if (s == null)
            {
                return RedirectToAction("Index", "ShopManagement", new { result = "EditFailed" });
            }

            return View(s);

        }

        [HttpPost]
        public ActionResult Edit(Shop s)
        {

           
               bool result = _shopService.Update(s);
            if(result)
            {
              return RedirectToAction("Index", "ShopManagement", new { result = "EditSuccess" });
            }
            
            return RedirectToAction("Index", "ShopManagement", new { result = "EditFailed" });
        }




        public JsonResult UpdateDistrictList(int? cityID)
        {

            if (cityID.HasValue == false)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            var lstDist = _districtService.GetByCityID(cityID.GetValueOrDefault(-1)).ToList();

            if (lstDist == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);

            }

            return this.Json(new
            {
                Result = (from obj in lstDist select new { ID = obj.ID, Name = obj.Name })
            }
                   , JsonRequestBehavior.AllowGet);

        }

        public JsonResult UpdateWardList(int? districtID)
        {
            if (districtID.HasValue == false)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            List<Ward> lstWard = _wardService.GetByDistrictID(districtID.GetValueOrDefault(-1)).ToList();

            if (lstWard == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return this.Json(new
            {
                Result = (from obj in lstWard select new { ID = obj.ID, Name = obj.Name })
            }
               , JsonRequestBehavior.AllowGet);
        }



        public ActionResult SearchByNameOrDescription(string Filter, int curPage = 1, int pageSize = 5, string sort = "ID", string type = "asc" , string option = "Managing")
        {
           


                var listPaging = _shopService.SearchByNameOrDescription(Filter, curPage, pageSize, sort, type,option).ToList();


                var list = _shopService.SearchByNameOrDescription(Filter, 1, 100, sort, type,option).ToList(); // curpage =1 và pagesize rất lớn để skip 0 và take all
                if (list == null)
                {
                    return PartialView("SearchByNameOrDescription", null); 
                }


                int nPages = list.Count / pageSize;

                if (list.Count % pageSize > 0)
                {
                    nPages++;
                }

                ViewBag.Pages = nPages;
                ViewBag.Filter = Filter;
                ViewBag.curPage = curPage;
                ViewBag.Sort = sort;
                ViewBag.MyStyle = type;
                ViewBag.Option = option;
                ViewBag.PrevPage = ViewBag.curPage - 1;
                ViewBag.NextPage = ViewBag.curPage + 1;
                

                return PartialView("SearchByNameOrDescription", listPaging);
            

           

        }



        public ActionResult Delete(int id)
        {
                //check if that id exist in db

                Shop s = _shopService.GetShopByID(id);
                if (s == null)
                {
                    return RedirectToAction("Index", "AccountManagement" , new { result = "DeleteFailed" } );
                }

                // found user then soft delete

                bool result =  _shopService.SoftDelete(s);
                if (result)
                {
                    return RedirectToAction("Index", "ShopManagement", new { result = "DeleteSuccess" });
                }
                return RedirectToAction("Index", "ShopManagement", new { result = "DeleteFailed" });

        }


        public ActionResult PartialViewAddShop()
        {
            return PartialView();
        }



        public ActionResult PartialViewEditShop(int id)
        {
           
           
               Shop s = _shopService.GetShopByID(id);

           
         
            return PartialView(s);
        }




        public ActionResult PartialViewListCity(int? wardID)
        {
            List<City> lstCity;
            if (wardID == null)
            {
                lstCity = _cityService.GetAll().ToList();
            }

            else
            {
                Ward w = _wardService.GetSingleById(wardID.GetValueOrDefault(-1));
                District d = _districtService.GetByID(w.DistrictID);
                lstCity = _cityService.GetAll().ToList();
                ViewBag.CityID = d.CityID;
            }
            
            return PartialView(lstCity);
        }


        public ActionResult PartialViewListWard(int? WardID)
        {
            List<Ward> lstWard;
            if (WardID == null)
            {
                District firstDistrict = _districtService.GetAll().FirstOrDefault();

                lstWard = _wardService.GetByDistrictID(firstDistrict.ID).ToList();
            }

            else {
                Ward w = _wardService.GetByID(WardID.GetValueOrDefault(-1));
                District d = _districtService.GetByID(w.DistrictID);
                lstWard = _wardService.GetByDistrictID(d.ID).ToList();
                ViewBag.WardID = WardID;
            }

            return PartialView(lstWard);
        }


        public ActionResult PartialViewListDistrict(int? WardID)
        {
            List<District> lstDistrict;
            if (WardID == null)
            {
                City firstCity = _cityService.GetAll().FirstOrDefault();
                lstDistrict = _districtService.GetByCityID(firstCity.ID).ToList();
            }
            else
            {
                Ward w = _wardService.GetByID(WardID.GetValueOrDefault(-1));
                District d = _districtService.GetByID(w.DistrictID);
              

                lstDistrict = _districtService.GetByCityID(d.CityID).ToList();
                ViewBag.DistrictID = w.DistrictID;
            }

            return PartialView(lstDistrict);
        }
    }
}