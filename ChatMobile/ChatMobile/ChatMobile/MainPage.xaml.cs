using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Xamarin.Forms;

namespace ChatMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Test();
        }

        private void Test()
        {
            var connection =
                new HubConnection("http://localhost:55711/signalr/", useDefaultUrl: false);

            var proxy = connection.CreateHubProxy("MainChatHub");

            connection.Start().Wait();
        }
    }
}
