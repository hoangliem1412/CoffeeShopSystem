using CoffeeShop.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Web.Controllers
{
    public class OrderController : Controller
    {
        static List<Order> listOrder; //chứa kết quả 
        static int totalPage=0;

        //Khởi tạo service
        IOrderService _orderService;
        IOrderProductService orderProductService;
        ITableService tableService;


        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="tableService"></param>
        /// <param name="orderProductService2"></param>
        public OrderController(IOrderService orderService, IOrderProductService orderProductService2, ITableService tableService2)
        {
            this._orderService = orderService;
            this.orderProductService = orderProductService2;
            this.tableService = tableService2;        
        }

        /// <summary>
        /// Page index
        /// </summary>
        /// <returns></returns>
        // GET: Order
        public ActionResult Index()
        {

            ViewBag.ListTable = tableService.GetByShop(1);
            listOrder = _orderService.GetAll().Where(o => o.Status == false).ToList();
            return View(listOrder);
        }


        /// <summary>
        ///Lấy danh sách sản phẩm theo ID hóa đơn 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //POST: GetListOrderProductByOrderID
        [HttpPost]
        public JsonResult GetListOrderProductByOrderID(int id)
        {
            var result = orderProductService.GetListOrderProductByOrderID(id).Select(o => new { id = o.ID, name = o.Product.Name, quantity = o.Quantity, price = o.Price, money = o.Money, });
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Tạo & Gán hóa đơn vào session 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //POST: SetOrderToSession
        [HttpPost]
        public JsonResult SetOrderToSession(int id)
        {          
            var obj = _orderService.GetByID(id);
            var list = orderProductService.GetListOrderProductByOrderID(id);
            bool? stt = obj.Status.HasValue ? obj.Status: false;
            CurrentContext.SetAllItem().AddInfoOrder(obj.ID,obj.TableID, stt);

            foreach (var p in list)
            {
                var item = new OrderProductItem
                {
                    ID = p.ID,
                    quantity = p.Quantity,
                    price = decimal.Parse(p.Price.ToString()),
                };
               
                CurrentContext.SetAllItem().AddItem(item);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Xóa sản phẩm khỏi chi tiết hóa đơn trong session
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //POST: RemoveOrderProduct
        [HttpPost]
        public JsonResult RemoveOrderProduct(int id)
        {
            CurrentContext.GetAll().RemoveItem(id);            
            return Json(CurrentContext.GetAll().TotalMoney(), JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// Cập nhật chi tiết hóa đơn trong session
        /// </summary>
        /// <param name="id"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        //POST: UpdateOrderProduct
        [HttpPost] 
        public JsonResult UpdateOrderProduct(int id, int q)
        {
            CurrentContext.GetAll().UpdateItem(id, q);
            return Json(CurrentContext.GetAll().TotalMoney(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lưu cập nhật hóa đơn vào database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tableID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        //POST:UpdateOrder
        [HttpPost]
        public JsonResult UpdateOrder(int id,int tableID, bool status)
        {
            var order = new Order();
            order.ID = id;
            order.TableID = tableID;
            order.Status = status;
           
            var list = CurrentContext.GetAll().Items; 
            foreach(var item in list)
            {
                var orderPro = new OrderProduct();
                orderPro.ID = item.ID;
                orderPro.Quantity = int.Parse(item.quantity.ToString());
                orderProductService.Update(orderPro);
            }
            
            var listItemDelete = CurrentContext.GetAll().ItemsDelete; 
            if (listItemDelete.Count > 0)
            {
                foreach (var item in listItemDelete)
                {
                    orderProductService.Delete(item.ID);
                }
            }

            orderProductService.Save();
            _orderService.Update(order);
            _orderService.Save();
          
            return Json(order, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// Tìm kiếm theo IDOrder,TableName & CustomerName
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        //POST:Search
        [HttpPost]
        public JsonResult Search(string keyword)

        {
            var result = _orderService.SearchByIDandTable(keyword,listOrder);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Lọc theo hóa đơn thanh toán hoặc chưa thanh toán
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        //POST:FilterStatus
        [HttpPost]
        public JsonResult FilterStatus(string status)
        {
            listOrder = new List<Order>();
            var lst = _orderService.GetByStatus(status,ref listOrder);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
		
        /// <summary>
        /// Filter by date and customerName and tableID
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="aSFromDate"></param>
        /// <param name="aSToDate"></param>
        /// <param name="aSTableName"></param>
        /// <returns></returns>
		[HttpPost]
        public JsonResult AdvancedSearch(string customerName,string aSFromDate, string aSToDate, int aSTableName)
        {
            var result=_orderService.SearchAdvanced(customerName,aSFromDate,aSToDate,aSTableName,ref listOrder);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}