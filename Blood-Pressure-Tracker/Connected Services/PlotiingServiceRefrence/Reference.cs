﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blood_Pressure_Tracker.PlotiingServiceRefrence {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PlotiingServiceRefrence.IPlottingService")]
    public interface IPlottingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlottingService/Plot_Chart", ReplyAction="http://tempuri.org/IPlottingService/Plot_ChartResponse")]
        byte[] Plot_Chart(string[] date, int[] dias, int[] sys);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlottingService/Plot_Chart", ReplyAction="http://tempuri.org/IPlottingService/Plot_ChartResponse")]
        System.Threading.Tasks.Task<byte[]> Plot_ChartAsync(string[] date, int[] dias, int[] sys);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPlottingServiceChannel : Blood_Pressure_Tracker.PlotiingServiceRefrence.IPlottingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PlottingServiceClient : System.ServiceModel.ClientBase<Blood_Pressure_Tracker.PlotiingServiceRefrence.IPlottingService>, Blood_Pressure_Tracker.PlotiingServiceRefrence.IPlottingService {
        
        public PlottingServiceClient() {
        }
        
        public PlottingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PlottingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlottingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlottingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public byte[] Plot_Chart(string[] date, int[] dias, int[] sys) {
            return base.Channel.Plot_Chart(date, dias, sys);
        }
        
        public System.Threading.Tasks.Task<byte[]> Plot_ChartAsync(string[] date, int[] dias, int[] sys) {
            return base.Channel.Plot_ChartAsync(date, dias, sys);
        }
    }
}