using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blood_Pressure_Tracker.Models
{
    public class Database : ApplicationDbContext
    {
        public DbSet<PressureMeasure> PressureMeasures { get; set; }
    }
}