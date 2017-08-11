using System;
using System.Web.Mvc;
using CoffeeShop.Service;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        IProductService  _productService ;
        IProductCategoryService _cateService;
       
        public ProductController(IProductService productService , IProductCategoryService categoryService)
        {
            this._productService = productService;
            this._cateService = categoryService;
        }
        public ActionResult Index()
        {
            var list = _productService.GetAll();
            return View(list);
        }

        // GET: Product/Details/5
        public PartialViewResult Details(int id)
        {
            return PartialView();
        }

        // GET: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            _productService.Add(product);
            _productService.Save();
            return View();
        }

      
        // GET: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            _productService.Update(product);
            _productService.Save();
            return View();
        }
        public ActionResult Delete(int id)
        {
            try
            {
                //server side code
                _productService.Delete(id);
                _productService.Save();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet); ;
            }
        }
  
    }
}
