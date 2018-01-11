using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentHelper.Startup))]
namespace StudentHelper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
