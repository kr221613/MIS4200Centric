using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIS4200CentricTeam4.Startup))]
namespace MIS4200CentricTeam4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
