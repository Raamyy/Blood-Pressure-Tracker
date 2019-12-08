using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blood_Pressure_Tracker.Models
{
    public class PressureMeasure
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public int Systole { get; set; }
        public int Diastole { get; set; }
        public DateTime Date { get; set; }
    }
}