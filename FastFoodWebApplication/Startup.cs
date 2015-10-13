using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FastFoodWebApplication.Startup))]
namespace FastFoodWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
