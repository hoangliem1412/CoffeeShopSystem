using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class GroupTableController : Controller
    {
        // GET: GroupTable
        IGroupTableService groupTableService;
        public GroupTableController(IGroupTableService groupTableService)
        {
            this.groupTableService = groupTableService;
        }
        public ActionResult Search()
        {
            return View(this.groupTableService.GetByShop(1));
        }

        [HttpPost]
        public ActionResult Edit(GroupTable gt)
        {
            groupTableService.Update(gt);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int? ID)
        {
            return Json(groupTableService.Delete(ID.Value), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(GroupTable gt)
        {
            groupTableService.Add(gt);
            groupTableService.Save();
            var result = new { ID = gt.ID, Name = gt.Name, Surcharge = gt.Surcharge, TableCount = gt.Tables.Count, Description = gt.Description};
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SearchCondition(string option)
        {
            var searchResult = groupTableService.SearchCondition(option).ToList();
            var resultToReturn = new { data = searchResult, option = option };
            return Json(resultToReturn, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Recover(int ID)
        {
            return Json(groupTableService.Recover(ID), JsonRequestBehavior.AllowGet);
        }
    }
}