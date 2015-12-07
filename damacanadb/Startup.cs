using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(damacanadb.Startup))]
namespace damacanadb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
