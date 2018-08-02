using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace ChatMobile
{
    public class ConnectionClient
    {
        public static EventHandler Connected;
        public HubConnection ServerConnection;
        public IHubProxy Hub;

        public ConnectionClient() { }

        public ConnectionClient(string url, string hubName)
        {
            ServerConnection = new HubConnection(url);
            Hub = ServerConnection.CreateHubProxy(hubName);
            ServerConnection.Start();

#pragma warning disable 4014
            Connect();
#pragma warning restore 4014
        }

        private async Task<bool> Connect()
        {
            try
            {
                await ServerConnection.Start();
                if (ServerConnection.State == ConnectionState.Connected)
                {
                    await Task.Delay(5000);
                    Connected.Invoke(this, EventArgs.Empty);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }
    }
}
