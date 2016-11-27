using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportTourism.Startup))]
namespace SportTourism
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
