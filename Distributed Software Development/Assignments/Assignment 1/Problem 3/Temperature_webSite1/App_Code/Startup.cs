using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Temperature_webSite1.Startup))]
namespace Temperature_webSite1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
