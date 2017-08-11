using CoffeeShop.Data.Repositories;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        IProductCategoryRepository _category;
        public CategoryController(IProductCategoryRepository category)
        {
             _category = category;
        }
        // GET: Category
        public ActionResult Index()
        {
            var list = _category.GetAll();
            return View(list);
        }
        public ActionResult ListCate()
        {
            var list = _category.GetAll();
            return View(list);
        }
        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
