using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        ITableService tableService;
        IGroupTableService groupTableService;
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <param name="tableService"></param>
        /// <param name="groupTableService"></param>
        public TableController(ITableService tableService, IGroupTableService groupTableService)
        {
            //Create 2 service
            this.tableService = tableService;
            this.groupTableService = groupTableService;
        }

        /// <summary>
        /// View index
        /// </summary>
        /// <returns>List<Table>, List<ViewBag.GroupTable></returns>
        public ActionResult Search()
        {
            //Gọi service GetByShop
            ViewBag.GroupTable = this.groupTableService.GetByShop(1);
            return View(this.tableService.GetByShop(1)); //Trả về danh sách table của shop
        }

        /// <summary>
        /// Cập nhật table
        /// </summary>
        /// <param name="t">Table</param>
        /// <returns>Json</returns>
        [HttpPost]
        public ActionResult Edit(Table t)
        {
            //Gọi service Update
            tableService.Update(t);
            //Save dữ liệu
            tableService.Save();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Thêm table
        /// </summary>
        /// <param name="t">Table</param>
        /// <returns>Json(ID, Name, GroupTableName, GroupTableID, OrderCount, Des)</returns>
        [HttpPost]
        public ActionResult Add(Table t)
        {
            //Gọi service Add
            tableService.Add(t);
            //Save
            tableService.Save();
            //Gọi service GetByID để lấy table vừa thêm
            var ressult = tableService.GetByID(t.ID);
            //Gọi service GetByID của grouptable lấy thông tin của group
            var resultGroupTable = groupTableService.GetByID(t.GroupTableID);
            var data = new { ID = ressult.ID, Name = ressult.Name, GroupTableName = resultGroupTable.Name, GroupTableID = resultGroupTable.ID, OrderCount = ressult.Orders.Count, Des = ressult.Description};
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Xóa table
        /// </summary>
        /// <param name="ID">int</param>
        /// <returns>Json<true, false></returns>
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            //Gọi service Delele
            return Json(tableService.Delete(ID), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Search cơ bản
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ActionResult SearchBase(string text)
        {
            var searchResult = tableService.SearchBase(text).ToList();
            return Json(searchResult, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Search theo tình trạng của option
        /// </summary>
        /// <param name="option">string</param>
        /// <returns>dynamic<List<data>, option></returns>
        [HttpPost]
        public ActionResult SearchCondition(string option)
        {
            //Gọi service SearchCondition
            var searchResult = tableService.SearchCondition(option).ToList();
            //gán kết quả trả về
            var resultToReturn = new { data = searchResult, option = option };
            return Json(resultToReturn, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Phục hồi tình trạng xóa của Table
        /// </summary>
        /// <param name="ID">int</param>
        /// <returns>Json<true, false></returns>
        [HttpPost]
        public ActionResult Recover(int ID)
        {
            //Gọi service Recover
            return Json(tableService.Recover(ID), JsonRequestBehavior.AllowGet);
        }
    }
}