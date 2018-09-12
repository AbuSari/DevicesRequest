using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevicesRequest.Startup))]
namespace DevicesRequest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
