using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Site_Lab12.Startup))]
namespace Site_Lab12
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.MapSignalR();
        }
    }
}
