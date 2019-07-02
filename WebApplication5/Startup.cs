using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication5.Startup))]
namespace WebApplication5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
