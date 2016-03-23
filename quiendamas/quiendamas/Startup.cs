using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(quiendamas.Startup))]
namespace quiendamas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
