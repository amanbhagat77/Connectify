using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Connectify.Startup))]
namespace Connectify
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
