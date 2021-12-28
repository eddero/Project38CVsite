using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project38CVsite.Startup))]
namespace Project38CVsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
