using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Web.Helpers;

namespace Plotting_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PlottingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PlottingService.svc or PlottingService.svc.cs at the Solution Explorer and start debugging.
    public class PlottingService : IPlottingService
    {
        public Byte[] Plot_Chart(List<string> date, List<int> dias, List<int> sys)
        {
            var myChart = new Chart(width: 600, height: 400).AddTitle("Blood Pressure Graph ").AddSeries(name: "Systol ", chartType: "line",
                xValue: date,
                yValues: sys).AddSeries(name: "Diastol", chartType: "line", xValue: date, yValues: dias);
            myChart.AddLegend(title: "Blood pressure Graphs", name: "No Name");
            return myChart.GetBytes();
        }
    }
}
