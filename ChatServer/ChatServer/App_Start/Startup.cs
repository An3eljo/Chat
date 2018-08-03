using ChatServer;
using ChatServer.Library;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace ChatServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Init();
            app.MapSignalR();
        }

        private void Init()
        {
            IdCreator.Initialize();
        }
    }
}
