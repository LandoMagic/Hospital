using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalModel;
using HospitalRepository.DBContext;
using System.IO;
using HospitalService.Services;

namespace HospitalWeb.Controllers
{
    public class ImmunizationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly FileService _fileService;
        // GET: Immunizations
        public ActionResult Index()
        {
            return View(db.Immunizations.ToList());
        }

        private string uploadimage(HttpPostedFileBase file)
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


        // GET: Immunizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return HttpNotFound();
            }
            return View(immunization);
        }

        // GET: Immunizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Immunizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreateBy,DateModified,Detail,ImageUrl")] Immunization immunization, HttpPostedFileBase file)
        {
            var url = uploadimage(file); //location of the sotr image afer upload

            if (!string.IsNullOrWhiteSpace(url))
            {
                immunization.ImageUrl = url;
                if (ModelState.IsValid)
                {

                    db.Immunizations.Add(immunization);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(immunization);

        }

        // GET: Immunizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return HttpNotFound();
            }
            return View(immunization);
        }

        // POST: Immunizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreateBy,DateModified,Detail,ImageUrl")] Immunization immunization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(immunization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(immunization);
        }

        // GET: Immunizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return HttpNotFound();
            }
            return View(immunization);
        }

        // POST: Immunizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Immunization immunization = db.Immunizations.Find(id);
            db.Immunizations.Remove(immunization);
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
