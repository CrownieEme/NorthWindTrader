using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorhtWindTraders.Startup))]
namespace NorhtWindTraders
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
