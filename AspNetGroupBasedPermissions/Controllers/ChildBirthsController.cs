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

namespace AspNetGroupBasedPermissions.Controllers
{
    public class ChildBirthsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChildBirths
        public ActionResult Index()
        {
            return View(db.ChildBirths.ToList());
        }

        // GET: ChildBirths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildBirth childBirth = db.ChildBirths.Find(id);
            if (childBirth == null)
            {
                return HttpNotFound();
            }
            return View(childBirth);
        }

        // GET: ChildBirths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChildBirths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameOfChild,DateOfBirth,PlaceOfBirth,Gender,MotherName,FatherName")] ChildBirth childBirth)
        {
            if (ModelState.IsValid)
            {
                db.ChildBirths.Add(childBirth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(childBirth);
        }

        // GET: ChildBirths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildBirth childBirth = db.ChildBirths.Find(id);
            if (childBirth == null)
            {
                return HttpNotFound();
            }
            return View(childBirth);
        }

        // POST: ChildBirths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameOfChild,DateOfBirth,PlaceOfBirth,Gender,MotherName,FatherName")] ChildBirth childBirth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childBirth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(childBirth);
        }

        // GET: ChildBirths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildBirth childBirth = db.ChildBirths.Find(id);
            if (childBirth == null)
            {
                return HttpNotFound();
            }
            return View(childBirth);
        }

        // POST: ChildBirths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChildBirth childBirth = db.ChildBirths.Find(id);
            db.ChildBirths.Remove(childBirth);
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
