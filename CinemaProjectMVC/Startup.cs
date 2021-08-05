using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaProjectMVC.Startup))]
namespace CinemaProjectMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
