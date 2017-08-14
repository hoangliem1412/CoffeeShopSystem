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

        /// <summary>
        /// View quản lý
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Search()
        {
            return View(this.groupTableService.GetByShop(1));
        }

        /// <summary>
        /// Cập nhật grouptable
        /// </summary>
        /// <param name="gt">GroupTable</param>
        /// <returns>Json<bool></returns>
        [HttpPost]
        public ActionResult Edit(GroupTable gt)
        {
            groupTableService.Update(gt);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Xóa grouptable
        /// </summary>
        /// <param name="ID">int</param>
        /// <returns>Json<bool></returns>
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            return Json(groupTableService.Delete(ID), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Thêm grouptable
        /// </summary>
        /// <param name="gt">GroupTable</param>
        /// <returns>Json<ID, Name, Surcharge, TableCount, Description></returns>
        [HttpPost]
        public ActionResult Add(GroupTable gt)
        {
            gt.ShopID = 1;
            groupTableService.Add(gt);
            groupTableService.Save();
            var result = new { ID = gt.ID, Name = gt.Name, Surcharge = gt.Surcharge, TableCount = gt.Tables.Count, Description = gt.Description };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Search theo tùy chọn (đã xóa <> chưa xóa)
        /// </summary>
        /// <param name="delete">bool</param>
        /// <returns>Json<List<data>, bool></returns>
        [HttpPost]
        public ActionResult SearchCondition(bool delete)
        {
            var resultToReturn = new { data = groupTableService.SearchCondition(delete), delete = delete };
            return Json(resultToReturn, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Phục hồi grouptable đã xóa
        /// </summary>
        /// <param name="ID">int</param>
        /// <returns>Json<bool></returns>
        [HttpPost]
        public ActionResult Recover(int ID)
        {
            return Json(groupTableService.Recover(ID), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Search nâng cao
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="fromSurcharge">decimal</param>
        /// <param name="toSurcharge">decimal</param>
        /// <param name="delete">bool</param>
        /// <returns>Json<List<data>, bool></returns>
        public ActionResult SearchAdvanced(string name, decimal fromSurcharge, decimal toSurcharge, bool delete)
        {
            //Gọi service SearchAdvanced
            var resultToReturn = new { data = groupTableService.SearchAdvanced(name, fromSurcharge, toSurcharge, delete), delete = delete };
            return Json(resultToReturn, JsonRequestBehavior.AllowGet);
        }
    }
}