using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAplicacion.Startup))]
namespace WebAplicacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
