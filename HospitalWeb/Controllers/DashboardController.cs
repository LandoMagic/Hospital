using HospitalRepository.DBContext;
using HospitalWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalWeb.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult ViewDashboard()
        {
            return View();
        }
        
        public JsonResult CountDeathLastSevenDays(DateTime? endDate)
        {
            if(endDate == null)
            {
                var compareDate = DateTime.Now.AddDays(-7);
               var count = _db.Deaths.Where(d => d.DateOfDeath >= compareDate).GroupBy(d => d.DateOfDeath);
                return Json(count, JsonRequestBehavior.AllowGet);

            }

            return null;

        }

        public JsonResult CountBirthLastSevenDays(DateTime? endDate)
        {
            if (endDate == null)
            {
                var compareDate = DateTime.Now.AddDays(-7);
                var count = _db.ChildBirth.Where(d => d.DateOfBirth >= compareDate).GroupBy(d => d.DateOfBirth);
                return Json(count, JsonRequestBehavior.AllowGet);

            }

            return null;

        }

        public JsonResult CountAppointment(DateTime? endDate)
        {
            if (endDate == null)
            {
                var compareDate = DateTime.Now.AddDays(-7);
              
                var count = _db.Appointments.Count();
                return Json(count, JsonRequestBehavior.AllowGet);

            }

            return null;

        }


     public JsonResult GetSCoutnBirth()
        {
            var chartViewModel = new ChartsViewModel();

            chartViewModel.countBirth = _db.ChildBirth.Where(a => a.DateOfBirth.Day == DateTime.Now.Day&& a.DateOfBirth.Month == DateTime.Now.Month).Count();
            chartViewModel.countDeath = _db.Deaths.Count();
            chartViewModel.countBodyOut = _db.BodyOuts.Count();

            return Json(chartViewModel, JsonRequestBehavior.AllowGet);
        }

    }
}