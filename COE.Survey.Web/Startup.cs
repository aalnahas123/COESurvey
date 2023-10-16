using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(COE.Survey.Web.Startup))]
namespace COE.Survey.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
