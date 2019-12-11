using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Blood_Pressure_Tracker.Web_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDietPlan" in both code and config file together.
    [ServiceContract]
    public interface IDietPlan
    {
        [OperationContract]
        string GetBloodPressureType(uint systolic, uint diastolic);
        Dictionary<string, string> GenerateLowPressureDiet();
        Dictionary<string, string> GenerateHighPressureDiet();
        Dictionary<string, string> GenerateNormalPressureDiet();
        [OperationContract]
        Dictionary<string, string> GetPreferDietPlan(uint systolic, uint diastolic);
    }
}
