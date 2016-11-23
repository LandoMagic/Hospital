using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetGroupBasedPermissions.Model;
using AspNetGroupBasedPermissions.Repository.DBContext;
using AspNetGroupBasedPermissions.Service.Services;

namespace AspNetGroupBasedPermissions.Controllers
{
    public class DrugInventoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly PatientService _patientService = new PatientService();
        // GET: DrugInventories
        public ActionResult Index()
        {
            return View(db.DrugInventories.ToList());
        }

        // GET: DrugInventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugInventory drugInventory = db.DrugInventories.Find(id);
            if (drugInventory == null)
            {
                return HttpNotFound();
            }
            return View(drugInventory);
        }

        // GET: DrugInventories/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(_patientService.GetAllPatiens(), "Id", "Firstname");
            return View();
        }

        // POST: DrugInventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DrugGenericName,DrugBrandName,Strength,DosageForm,ExpiryDate,BatchNumber,Stock,DateReceived,StockQuantity,MainCategory")] DrugInventory drugInventory)
        {
            ViewBag.ApplicationUserId = new SelectList(_patientService.GetAllPatiens(), "Id", "Firstname", drugInventory.ApplicationUserId);
            if (ModelState.IsValid)
            {
                db.DrugInventories.Add(drugInventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drugInventory);
        }

        // GET: DrugInventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugInventory drugInventory = db.DrugInventories.Find(id);
            if (drugInventory == null)
            {
                return HttpNotFound();
            }
            return View(drugInventory);
        }

        // POST: DrugInventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DrugGenericName,DrugBrandName,Strength,DosageForm,ExpiryDate,BatchNumber,Stock,DateReceived,StockQuantity,MainCategory")] DrugInventory drugInventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drugInventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drugInventory);
        }

        // GET: DrugInventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugInventory drugInventory = db.DrugInventories.Find(id);
            if (drugInventory == null)
            {
                return HttpNotFound();
            }
            return View(drugInventory);
        }

        // POST: DrugInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrugInventory drugInventory = db.DrugInventories.Find(id);
            db.DrugInventories.Remove(drugInventory);
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
