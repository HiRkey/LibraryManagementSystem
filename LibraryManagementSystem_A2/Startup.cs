using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryManagementSystem_A2.Startup))]
namespace LibraryManagementSystem_A2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
