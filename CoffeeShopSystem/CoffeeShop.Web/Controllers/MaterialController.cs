using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CoffeeShop.Web.Controllers
{
    public class MaterialController : Controller
    {
        private IMaterialService materialService;
        private IMaterialCategoryService materialCategoryService;

        public MaterialController(IMaterialService mateService, IMaterialCategoryService mateCateService)
        {
            this.materialService = mateService;
            this.materialCategoryService = mateCateService;
        }

        // GET: Material
        public ActionResult Index()
        {
            //var materials = materialService.GetMulti(x => !x.IsDelete ?? true);
            ViewBag.MateCateList = materialCategoryService.GetAll();
            return View();// materials.ToList());
        }

        public ActionResult LoadData(string keyword, int status, int page, int pageSize = 5)
        {
            int totalRow = 0;
            var listMaterial = materialService.GetSearchStatusPaging(keyword, status, page, pageSize, out totalRow);
            return this.Json(new
            {
                data = listMaterial,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Insert()
        {
            return Json(new { status = true });
        }

        public JsonResult SubmitForm(string strMaterial)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Material material = serializer.Deserialize<Material>(strMaterial);
            bool status = false;
            string message = string.Empty;
            bool action;
            //add new employee if id = 0
            if (material.ID == 0)
            {
                //material.CreatedDate = DateTime.Now;
                material.IsDelete = false;
                materialService.Add(material);
                action = true;
            }
            else
            {
                //update existing DB
                //save db
                material.IsDelete = false;
                materialService.Update(material);
                action = false;
            }
            try
            {
                materialService.Save();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                message = ex.Message;
            }

            return Json(new
            {
                status = status,
                message = message,
                action = action
            });
        }

        public JsonResult GetDetailEdit(int id)
        {
            Material material = materialService.GetSingleByID(id);
            return Json(new
            {
                material = material,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            string message = string.Empty;
            bool status;
            materialService.Delete(id);
            try
            {
                materialService.Save();
                status = true;
            }
            catch (SqlException sEx)
            {
                message = sEx.Message;
                status = false;
            }

            return Json(new
            {
                status = status,
                message = message
            }, JsonRequestBehavior.AllowGet);
        }
        // GET: Material/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Material material = db.Materials.Find(id);
        //    if (material == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(material);
        //}

        //// GET: Material/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CategoryID = new SelectList(db.MaterialCategories, "ID", "Name");
        //    return View();
        //}

        //// POST: Material/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Name,CategoryID,UnitPrice,Inventory,Description,CreatedDate,IsDelete")] Material material)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        materialService.Add(material);
        //        materialService.Save();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MateCateList = materialCategoryService.GetAll();
        //    //ViewBag.CategoryID = new SelectList(db.MaterialCategories, "ID", "Name", material.CategoryID);
        //    return View(material);
        //}

        //// GET: Material/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Material material = db.Materials.Find(id);
        //    if (material == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoryID = new SelectList(db.MaterialCategories, "ID", "Name", material.CategoryID);
        //    return View(material);
        //}

        //// POST: Material/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Name,CategoryID,UnitPrice,Inventory,Description,CreatedDate,IsDelete")] Material material)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(material).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoryID = new SelectList(db.MaterialCategories, "ID", "Name", material.CategoryID);
        //    return View(material);
        //}

        //// GET: Material/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Material material = db.Materials.Find(id);
        //    if (material == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(material);
        //}

        //// POST: Material/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Material material = db.Materials.Find(id);
        //    db.Materials.Remove(material);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}