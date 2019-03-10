using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XanhShop.Web.Startup))]
namespace XanhShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
