using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Blood_Pressure_Tracker.Models;
using Microsoft.AspNet.Identity;

namespace Blood_Pressure_Tracker.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext database;

        public HomeController()
        {
            database = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            database.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Dashboard", new {email = User.Identity.Name});
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}