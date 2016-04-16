using Microsoft.Owin;
using Owin;
using PublicHealthApp.App_Start;


[assembly: OwinStartupAttribute(typeof(PublicHealthApp.Startup))]
namespace PublicHealthApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
