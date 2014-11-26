using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PS.Web.Startup))]
namespace PS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
