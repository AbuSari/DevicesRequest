using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevicesRequest.Startup))]
namespace DevicesRequest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "DevicesRequestCookie",
                LoginPath = new PathString("/auth/login")
            });
          //  ConfigureAuth(app);
        }


    }
}
