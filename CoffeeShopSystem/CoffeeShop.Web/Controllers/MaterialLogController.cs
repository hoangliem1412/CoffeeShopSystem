using System.Linq;
using System.Net;
using System.Web.Mvc;
using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;

namespace CoffeeShop.Web.Controllers
{
    public class MaterialLogController : Controller
    {
        private IMaterialLogService mLogService;
        private IMaterialService materialService;

        public MaterialLogController(IMaterialLogService mLogService, IMaterialService mateService)
        {
            this.mLogService = mLogService;
            this.materialService = mateService;
        }

        // GET: MaterialLog
        public ActionResult Index()
        {
            var materialLogs = mLogService.GetMulti(x => x.IsDelete == false);
            ViewBag.MateList = materialService.GetMulti(x => x.IsDelete == false);

            return View(materialLogs.ToList());
        }

        // GET: MaterialLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MaterialLog materialLog = mLogService.GetSingleById(id.Value);

            if (materialLog == null)
            {
                return HttpNotFound();
            }

            return View(materialLog);
        }

        // GET: MaterialLog/Create
        public ActionResult Create()
        {
            //ViewBag.MaterialID = new SelectList(db.MaterialCategories, "ID", "Name");
            //ViewBag.EmployeeID = new SelectList(db.Users, "ID", "Username");
            return View();
        }

        // POST: MaterialLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaterialID,EmployeeID,Inventory,UnitPrice,Type,Description,CreatedDate,IsDelete")] MaterialLog materialLog)
        {
            if (ModelState.IsValid)
            {
                //db.MaterialLogs.Add(materialLog);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.MaterialID = new SelectList(db.MaterialCategories, "ID", "Name", materialLog.MaterialID);
            //ViewBag.EmployeeID = new SelectList(db.Users, "ID", "Username", materialLog.EmployeeID);
            return View(materialLog);
        }

        // GET: MaterialLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MaterialLog materialLog = db.MaterialLogs.Find(id);
            //if (materialLog == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.MaterialID = new SelectList(db.MaterialCategories, "ID", "Name", materialLog.MaterialID);
            //ViewBag.EmployeeID = new SelectList(db.Users, "ID", "Username", materialLog.EmployeeID);
            //return View(materialLog);
            return null;
        }

        // POST: MaterialLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaterialID,EmployeeID,Inventory,UnitPrice,Type,Description,CreatedDate,IsDelete")] MaterialLog materialLog)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(materialLog).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.MaterialID = new SelectList(db.MaterialCategories, "ID", "Name", materialLog.MaterialID);
            //ViewBag.EmployeeID = new SelectList(db.Users, "ID", "Username", materialLog.EmployeeID);
            return View(materialLog);
        }

        // GET: MaterialLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MaterialLog materialLog = db.MaterialLogs.Find(id);
            //if (materialLog == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(materialLog);
            return null;
        }

        // POST: MaterialLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //MaterialLog materialLog = db.MaterialLogs.Find(id);
            //db.MaterialLogs.Remove(materialLog);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
