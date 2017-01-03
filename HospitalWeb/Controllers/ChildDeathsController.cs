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

namespace HospitalWeb.Controllers
{
    public class ChildDeathsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Deaths
        public ActionResult Index()
        {
            return View(db.Deaths.ToList());
        }

        // GET: Deaths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Death death = db.Deaths.Find(id);
            if (death == null)
            {
                return HttpNotFound();
            }
            return View(death);
        }

        // GET: Deaths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deaths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameOfChild,DateOfDeath,PlaceOfBirth,Gender,MotherName,FatherName,ImageUrl")] Death death)
        {
            if (ModelState.IsValid)
            {
                db.Deaths.Add(death);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(death);
        }

        // GET: Deaths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Death death = db.Deaths.Find(id);
            if (death == null)
            {
                return HttpNotFound();
            }
            return View(death);
        }

        // POST: Deaths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameOfChild,DateOfDeath,PlaceOfBirth,Gender,MotherName,FatherName,ImageUrl")] Death death)
        {
            if (ModelState.IsValid)
            {
                db.Entry(death).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(death);
        }

        // GET: Deaths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Death death = db.Deaths.Find(id);
            if (death == null)
            {
                return HttpNotFound();
            }
            return View(death);
        }

        // POST: Deaths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Death death = db.Deaths.Find(id);
            db.Deaths.Remove(death);
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
