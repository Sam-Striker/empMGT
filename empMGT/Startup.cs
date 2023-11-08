using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(empMGT.Startup))]
namespace empMGT
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
