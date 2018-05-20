using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eshop.WebUI.Startup))]
namespace Eshop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
