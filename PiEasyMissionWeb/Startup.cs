using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PiEasyMissionWeb.Startup))]
namespace PiEasyMissionWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
