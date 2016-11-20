using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shopomo.Startup))]
namespace Shopomo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
