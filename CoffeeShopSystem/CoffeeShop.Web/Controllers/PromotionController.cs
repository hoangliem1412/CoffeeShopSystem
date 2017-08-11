using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class PromotionController : Controller
    {

        //initialize service object
        IPromotionService _PromotionService;

        public PromotionController(IPromotionService PromotionService)
        {
            _PromotionService = PromotionService;
        }

        // GET: /Promotion/
        public ActionResult Index(int page = 1)
        {
            // totalitem, recordsPerPage
            ViewBag.Pages = _PromotionService.GetTotalPage(_PromotionService.GetActive().Count(), 5);
            ViewBag.CurPage = page;

            //IEnumerable<Promotion> list, recordsPerPage, page
            return View(_PromotionService.Paging(_PromotionService.GetActive(), 5, page));
        }




        [HttpPost]
        public ActionResult Create(Promotion promotion)
        {
            _PromotionService.Add(promotion);
            //_PromotionService.Save();

            // lastpage => Load đúng vị trí
            int lastpage = _PromotionService.GetTotalPage(_PromotionService.GetActive().Count(), 5);
            return RedirectToAction("Index", new { page = lastpage });
        }

        //[HttpPost]
        //public JsonResult Create(Promotion promotion)
        //{
        //    _PromotionService.Add(promotion);
        //    _PromotionService.Save();
        //    return Json(promotion);
        //}



        public JsonResult GetById(int idToGet)
        {
            Promotion promotion = _PromotionService.GetByID(idToGet);
            return Json(promotion, JsonRequestBehavior.AllowGet);
        }


        // 3. ShopId
        //POST: /Promotion/Edit
        [HttpPost]
        public JsonResult Edit(Promotion Promotion)
        {
            _PromotionService.Update(Promotion);
            //_PromotionService.Save();
            return Json("", JsonRequestBehavior.AllowGet);
        }



        //POST: /Promotion/Delete
        [HttpPost]
        public JsonResult Delete(int IdToDelete)
        {
            return Json(_PromotionService.Delete(IdToDelete), JsonRequestBehavior.AllowGet);
            ////Xóa thành công
            //if (_PromotionService.Delete(IdToDelete))
            //{
            //    _PromotionService.Save();
            //    return Json("Xóa thành công", JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Không thể xóa khuyến mãi đang trong hóa đơn", JsonRequestBehavior.AllowGet);
            //}
        }//5. Khóa ngoại


    }
}