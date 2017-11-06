using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SupportStudentSystem.Startup))]
namespace SupportStudentSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
