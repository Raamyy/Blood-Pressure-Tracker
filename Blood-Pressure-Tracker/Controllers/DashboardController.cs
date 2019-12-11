using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blood_Pressure_Tracker.Models;
using Blood_Pressure_Tracker.View_Models;

namespace Blood_Pressure_Tracker.Controllers
{
    public class DashboardController : Controller
    {
        private Database database;

        public DashboardController()
        {
            database = new Database();
        }

        protected override void Dispose(bool disposing)
        {
            database.Dispose();
        }

        // GET: Dashboard
        public ActionResult Index(string email)
        {
            ApplicationUser user = database.Users.SingleOrDefault(m => m.Email == email);
            return View(user);
        }

        public ActionResult AddPressureMeasure(ApplicationUser user)
        {
            AddPressureMeasureViewModel model = new AddPressureMeasureViewModel
            {
                User = user
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPressureMeasureForUser(AddPressureMeasureViewModel model)
        {
            ApplicationUser activeUser = database.Users.SingleOrDefault(c => c.Email == model.User.Email);
            model.Measure.User = activeUser;
            model.Measure.UserId = activeUser.Id;
            model.Measure.Date = DateTime.Now;
            database.PressureMeasures.Add(model.Measure);
            activeUser.PressureMeasures.Add(model.Measure);
            database.SaveChanges();
            return RedirectToAction("Index", "Dashboard", new { email = model.User.Email});
        }
    }
}