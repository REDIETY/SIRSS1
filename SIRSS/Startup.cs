using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIRSS.Startup))]
namespace SIRSS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
