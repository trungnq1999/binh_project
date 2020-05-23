using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simulation.Startup))]
namespace Simulation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
