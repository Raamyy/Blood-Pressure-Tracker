using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Helpers;

namespace Plotting_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlottingService" in both code and config file together.
    [ServiceContract]
    public interface IPlottingService
    {
        [OperationContract(IsOneWay = false)]
        Byte[] Plot_Chart(List<string> date, List<int> dias, List<int> sys);
    }
}
