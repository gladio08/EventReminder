using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventReminder.Startup))]
namespace EventReminder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
