using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5AndUnity.Startup))]
namespace MVC5AndUnity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
