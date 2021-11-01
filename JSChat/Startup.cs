using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JSChat.Startup))]
namespace JSChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
