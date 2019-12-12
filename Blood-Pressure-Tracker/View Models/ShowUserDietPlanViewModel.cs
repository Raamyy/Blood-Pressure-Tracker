using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blood_Pressure_Tracker.View_Models
{
    public class ShowUserDietPlanViewModel
    {
        public Dictionary<string, string> Dictionary { get; set; }
        public string bloodPressureCategory { get; set; }
    }
}