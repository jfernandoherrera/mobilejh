using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(listarproy.Startup))]
namespace listarproy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
