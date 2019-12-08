using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blood_Pressure_Tracker.Startup))]
namespace Blood_Pressure_Tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
