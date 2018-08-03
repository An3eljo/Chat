using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace ChatMobile
{
    public class Init
    {
        public static void Initialize()
        {
            InitializeConnectionClient();
            
        }

        private void InitializeReceivingMethods()
        {
            //ReceivingMethods.
            //var task = new Task();
            ReceivingMethods.ReceiveUserId += (sender, args) => { };
        }

        private static void InitializeConnectionClient()
        {
            Data.Instance.Client = new ConnectionClient(Data.ServerUrl, Data.HubName);
            //Data.Instance.Client.ServerConnection = new HubConnection(Data.ServerUrl);
            //Data.Instance.Client.Hub = Data.Instance.Client.ServerConnection.CreateHubProxy(Data.HubName);


            
            //var settings = XmlActions.Deserialize(XmlActions.SettingsFile, new Setting())
            //if (XmlActions.Deserialize("settings.xml", ) != null)
            //{
            //    ConnectionClient.Connected += (sender, e) =>
            //    {


            //        Data.Instance.Client.Hub.Invoke("Verify")
            //    };
            //}
        }
    }
}
