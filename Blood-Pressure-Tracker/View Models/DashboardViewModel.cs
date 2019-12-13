using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blood_Pressure_Tracker.Models;

namespace Blood_Pressure_Tracker.View_Models
{
    public class DashboardViewModel
    {
        public ApplicationUser ApplicationUser { get; set; } 
        public Byte[] ChartBytes { get; set; }
    }
}