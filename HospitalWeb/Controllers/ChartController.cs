using HospitalModel;
using HospitalRepository.DBContext;
using HospitalWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalWeb.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult column()
        {
            return View();

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