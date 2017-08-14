using System.Linq;
using System.Web.Mvc;
using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using System.Collections.Generic;
using CoffeeShop.Model;

namespace CoffeeShop.Web.Controllers
{
    public class MaterialLogController : Controller
    {
        private IMaterialLogService mLogService;
        private IMaterialService materialService;
        static IEnumerable<MaterialLog> logList;
        int rowPerPage = 10;
        static int totalItems = 0;

        public MaterialLogController(IMaterialLogService mLogService, IMaterialService mateService)
        {
            this.mLogService = mLogService;
            this.materialService = mateService;
        }

        // GET: MaterialLog
        public ActionResult Index()

        {
            logList = mLogService.GetAvailable().ToList();
            totalItems = logList.Count();
            ViewBag.MateList = materialService.GetMulti(x => x.IsDelete == false);
            ViewBag.TotalItems = totalItems;
            ViewBag.RowPerPage = rowPerPage;

            return View(logList.Take(rowPerPage));

        }

        public JsonResult Paging(int inRowPerPage, int currentPage)
        {
            var result = new { totalItems = logList.Count(), items = mLogService.Paging(logList, inRowPerPage, currentPage) };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByStatus(int inRowPerPage, int status, int currentPage = 1)
        {
            logList = mLogService.GetByStatus(logList, status);
            return Paging(inRowPerPage, currentPage);
        }

        // POST: MaterialLog/Create
        [HttpPost]
        public JsonResult Create(MaterialLog materialLog)
        {
            if (ModelState.IsValid)
            {
                mLogService.Add(materialLog);
                mLogService.Save();
                return Json("", JsonRequestBehavior.AllowGet);
            }

            return Json("Có lỗi xảy ra, vui lòng thử lại", JsonRequestBehavior.AllowGet);
        }

        // GET: MaterialLog/Edit/5
        public JsonResult Detail(int? id)
        {
            if (id == null)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

            var result = mLogService.GetSingleById(id.Value);

            return Json(mLogService.Flat(result), JsonRequestBehavior.AllowGet);
        }

        // POST: MaterialLog/Edit/5
        [HttpPost]
        public ActionResult Edit(MaterialLog materialLog)
        {
            if (ModelState.IsValid)
            {
                mLogService.Update(materialLog);
                mLogService.Save();
                return Json("", JsonRequestBehavior.AllowGet);
            }

            return Json("Có lỗi xảy ra, vui lòng thử lại", JsonRequestBehavior.AllowGet);
        }

        // POST: MaterialLog/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            mLogService.Delete(id);
            mLogService.Save();

            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchByName(string keyword, int rowPerPage)
        {
            logList = mLogService.SearchByName(keyword);
            var result = new { totalItems = logList.Count(), items = mLogService.Paging(logList, rowPerPage, 1) };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Search(MaterialLogSearchViewModel model/*, int rowPerPage*/)
        {
            logList = mLogService.Search(model);
            var result = new { totalItems = logList.Count(), items = mLogService.Paging(logList, model.RowPerPage, 1) };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
