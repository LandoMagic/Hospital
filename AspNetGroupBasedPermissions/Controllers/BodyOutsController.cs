using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalModel;
using HospitalRepository.DBContext;

namespace HospitalWeb.Controllers
{
    public class BodyOutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BodyOuts
        public ActionResult Index()
        {
            return View(db.BodyOuts.ToList());
        }

      
        private string uploadimage (HttpPostedFileBase file)
        {
            var path = "";
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                 path = Path.Combine(Server.MapPath("~/Image/BodyOut"), fileName);
                file.SaveAs(path);
            }

            return path;
        }

        // GET: BodyOuts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyOut bodyOut = db.BodyOuts.Find(id);
            if (bodyOut == null)
            {
                return HttpNotFound();
            }
            return View(bodyOut);
        }

        // GET: BodyOuts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BodyOuts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BodyOut bodyOut, HttpPostedFileBase file)
        {
            var url = uploadimage(file); //location of the sotr image afer upload
            if (url != "")
            {
                bodyOut.ImageUrl = url;
                if (ModelState.IsValid)
                {
                
                    db.BodyOuts.Add(bodyOut);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(bodyOut);
        }

        // GET: BodyOuts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyOut bodyOut = db.BodyOuts.Find(id);
            if (bodyOut == null)
            {
                return HttpNotFound();
            }
            return View(bodyOut);
        }

        // POST: BodyOuts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MotherName,FatherName,PlaceOfBirth,Gender")] BodyOut bodyOut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodyOut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bodyOut);
        }

        // GET: BodyOuts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyOut bodyOut = db.BodyOuts.Find(id);
            if (bodyOut == null)
            {
                return HttpNotFound();
            }
            return View(bodyOut);
        }

        // POST: BodyOuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BodyOut bodyOut = db.BodyOuts.Find(id);
            db.BodyOuts.Remove(bodyOut);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
