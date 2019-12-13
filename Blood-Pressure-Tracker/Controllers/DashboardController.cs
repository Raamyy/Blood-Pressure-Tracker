using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blood_Pressure_Tracker.Models;
using Blood_Pressure_Tracker.View_Models;
using System.Data.Entity;
using Blood_Pressure_Tracker.DietPlanRefrence;
using Blood_Pressure_Tracker.PlotiingServiceRefrence;

namespace Blood_Pressure_Tracker.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext database;

        public DashboardController()
        {
            database = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            database.Dispose();
        }

        // GET: Dashboard
        public ActionResult Index(string email)
        {
            PlotiingServiceRefrence.PlottingServiceClient plottingServiceClient = new PlottingServiceClient();
            ApplicationUser user = database.Users.Include(c => c.PressureMeasures).SingleOrDefault(m => m.Email == email);
            if (user == null)
                return HttpNotFound();
            List<string> datesList = new List<string>();
            List<int> diastolesList = new List<int>(), systolesList = new List<int>();
            foreach (var pressureMeasure in user.PressureMeasures)
            {
                datesList.Add(pressureMeasure.Date.ToString());
                diastolesList.Add(pressureMeasure.Diastole);
                systolesList.Add(pressureMeasure.Systole);
            }
            DashboardViewModel dashboardViewModel = new DashboardViewModel
            {
                ApplicationUser = user,
                ChartBytes = plottingServiceClient.Plot_Chart(datesList.ToArray(), diastolesList.ToArray(), systolesList.ToArray())
            };
            return View(dashboardViewModel);
        }

        public ActionResult AddPressureMeasure(ApplicationUser user)
        {
            if (user == null)
                return HttpNotFound();
            AddPressureMeasureViewModel model = new AddPressureMeasureViewModel
            {
                User = user
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPressureMeasureForUser(AddPressureMeasureViewModel model)
        {
            if (model == null)
                return HttpNotFound();
            ApplicationUser activeUser = database.Users.SingleOrDefault(c => c.Email == model.User.Email);
            model.Measure.User = activeUser;
            model.Measure.UserId = activeUser.Id;
            model.Measure.Date = DateTime.Now;
            database.PressureMeasures.Add(model.Measure);
            activeUser.PressureMeasures.Add(model.Measure);
            database.SaveChanges();
            return RedirectToAction("Index", "Dashboard", new { email = model.User.Email});
        }

        public ActionResult ShowUserDietPlan(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                return HttpNotFound();
            ShowUserDietPlanViewModel showUserDietPlanViewModel = new ShowUserDietPlanViewModel();
            applicationUser = database.Users.Include(c => c.PressureMeasures).SingleOrDefault(m => m.Email == applicationUser.Email);
            DietPlanRefrence.DietPlanClient serviceDietPlanClient =  new DietPlanClient();
            if (applicationUser.PressureMeasures.Count() != 0)
            {
                PressureMeasure measure = applicationUser.PressureMeasures.Last();
                var dictionary = serviceDietPlanClient.GetPreferDietPlan((uint)measure.Systole, (uint)measure.Diastole);
                showUserDietPlanViewModel.Dictionary = dictionary;
                showUserDietPlanViewModel.bloodPressureCategory =
                    serviceDietPlanClient.GetBloodPressureType((uint) measure.Systole, (uint) measure.Diastole);
            }
            else
            {
                showUserDietPlanViewModel.Dictionary = new Dictionary<string, string>();
                showUserDietPlanViewModel.bloodPressureCategory = "Invalid";
            }
            return View(showUserDietPlanViewModel);
        }
    }
}