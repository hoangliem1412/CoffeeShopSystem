using CoffeeShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class OrderController : Controller
    {
        IOrderService _tableService;
        IOrderProductService orderProductService;
        public OrderController(IOrderService tableService, IOrderProductService orderProductService2)
        {
            this._tableService = tableService;
            this.orderProductService = orderProductService2;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(_tableService.GetAll());
        }

        [HttpPost]
        public JsonResult GetListOrderProductByOrderID(int id)
        {
            var result = orderProductService.GetListOrderProductByOrderID(id).Select(o=>new {name=o.Product.Name,quantity=o.Quantity, price=o.Price, money=o.Money, });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}