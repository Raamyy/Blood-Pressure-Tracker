using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blood_Pressure_Tracker.Models;
using Blood_Pressure_Tracker.View_Models;

namespace Blood_Pressure_Tracker.Controllers
{
    public class PressureMeasureController : Controller
    {
        private ApplicationDbContext dbContext;

        public PressureMeasureController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult EditPressureMeasure(int id)
        {
            PressureMeasure pressureMeasure = dbContext.PressureMeasures.SingleOrDefault(m => m.Id == id);
            EditPressureMeasureViewModel editPressureMeasureViewModel = new EditPressureMeasureViewModel
            {
                Id = id,
                Date = pressureMeasure.Date,
                Diastole = pressureMeasure.Diastole,
                Systole = pressureMeasure.Systole
            };
            return View(editPressureMeasureViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPressureMeasure(EditPressureMeasureViewModel model)
        {
            PressureMeasure pressureMeasure = dbContext.PressureMeasures.SingleOrDefault(m => m.Id == model.Id);
            pressureMeasure.Diastole = model.Diastole;
            pressureMeasure.Systole = model.Systole;
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Dashboard", new { email = User.Identity.Name});
        }

        public ActionResult DeletePressureMeasure(int id)
        {
            PressureMeasure pressureMeasure = dbContext.PressureMeasures.SingleOrDefault(m => m.Id == id);
            dbContext.PressureMeasures.Remove(pressureMeasure);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Dashboard", new {email = User.Identity.Name});
        }
    }
}