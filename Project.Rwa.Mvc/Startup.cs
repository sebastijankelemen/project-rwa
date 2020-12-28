using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project.Rwa.Mvc.Startup))]
namespace Project.Rwa.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
