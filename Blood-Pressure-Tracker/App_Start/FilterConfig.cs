﻿using System.Web;
using System.Web.Mvc;

namespace Blood_Pressure_Tracker
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
