using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blood_Pressure_Tracker.View_Models
{
    public class EditPressureMeasureViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Diastole { get; set; }
        public int Systole { get; set; }
    }
}