using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blood_Pressure_Tracker.Models;

namespace Blood_Pressure_Tracker.View_Models
{
    public class EditAccountInformationViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public double  Weight { get; set; }
        public DateTime DataOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}