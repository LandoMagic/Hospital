﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using HospitalModel;
using HospitalRepository.DBContext;
using HospitalService.Services;
using HospitalWeb.ViewModels;

namespace HospitalWeb.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly PatientService _patientService = new PatientService();
        // GET: Appointment
        [Authorize(Roles = "CanViewAppointments")]
        public ActionResult Index()
        {
            var appList = new List<AppointmentViewModel>();
            
            var appresult = db.Appointments.ToList();
            foreach (var appointment in appresult )
            {
                var appp = new AppointmentViewModel();
               var app =
                    Mapper.Map<Appointment,AppointmentViewModel>(appointment);
                appp = app;
                appp.Patient=db.Users.Find(appointment.ApplicationUserId);
                appList.Add(appp);

            }
            return View(appList);
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

     
        // GET: Appointment/Create
        public ActionResult Create()
        {
           
            

            ViewBag.PatientViewmodelId = new SelectList(_patientService.GetAllPatiens(), "Id", "Firstname");
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(AppointmentViewModel appointment)
        {
            ViewBag.PatientViewmodelId = new SelectList(_patientService.GetAllPatiens(), "Id", "Firstname", appointment.PatientViewmodelId);

            if (!ModelState.IsValid)
            {
              
                return View();
            }
            try
            {
                var app =
                   Mapper.Map< AppointmentViewModel,Appointment>(appointment);
                
                app.Date = DateTime.Parse(appointment.Date.ToString(CultureInfo.InvariantCulture));
                app.ApplicationUserId = appointment.PatientViewmodelId;
                app.DateAdded = DateTime.Now;
               
                app.CreatedBy = User.Identity.Name;
                app.Reason = appointment.Reason;
                app.Description = appointment.Description;
                db.Appointments.Add(app);
                db.SaveChanges();

                return View("Index");
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
            Appointment appresult = db.Appointments.Find(id);
            if (appresult == null)
            {
                return HttpNotFound();
            }
            var appList = new List<AppointmentViewModel>();

           
           
                var appp = new AppointmentViewModel();
                 var app =
                     Mapper.Map<Appointment, AppointmentViewModel>(appresult);

            var firstOrDefault = _patientService.GetAllPatiens().FirstOrDefault(p => p.Id == appresult.ApplicationUserId);
            if (firstOrDefault != null)
                app.PatientViewmodelId = firstOrDefault.Id;


            return View(app);
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here....check if
              //    var app=  db.Appointments
               
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
            var appp = new AppointmentViewModel();
            var appppp =
                Mapper.Map<Appointment, AppointmentViewModel>(app);
            var firstOrDefault = _patientService.GetAllPatiens().FirstOrDefault(p => p.Id == app.ApplicationUserId);
            if (firstOrDefault != null)
                appppp.PatientViewmodelId = firstOrDefault.Id;

            //TODO get application user info using 
            // appp.Patient =db.applicationUSer.finf(app.applicationUSerId)
            if (app == null)
            {
                return HttpNotFound();
            }

            return View(appppp);
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
