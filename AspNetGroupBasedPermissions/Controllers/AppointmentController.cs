using AspNetGroupBasedPermissions.Model;
using AspNetGroupBasedPermissions.Repository;
using AspNetGroupBasedPermissions.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspNetGroupBasedPermissions.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            ViewBag.PatientViewmodelId = new SelectList(db.Patients.ToList(), "Id", "Firstname");
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(AppointmentViewModel appointnent)
        {


            if (!ModelState.IsValid)
            {
                ViewBag.PatientViewmodelId = new SelectList(db.Patients.ToList(), "Id", "Firstname", appointnent.PatientViewmodel.Id);
                return View();
            }
            try
            {
                var app = new Appointment();
                app.Date = appointnent.Date;
                app.PatientId = appointnent.PatientViewmodel.Id;
                app.DateAdded = DateTime.Now;
                app.CreatedBy = User.Identity.Name;
                app.Reason = appointnent.Reason;
                app.Description = appointnent.Description;
                db.Appointments.Add(app);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment app = db.Appointments.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here....check if
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment app = db.Appointments.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
               
                Appointment app = db.Appointments.Find(id);
              
                 db.Appointments.Remove(app);
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
