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
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        private string _text0;
        public string Text0
        {
            get { return _text0; }
            set
            {
                _text0 = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    SetTime();
                    //await Task.Delay(50);
                }
            });
            Text = "Not Connected";
            InitializeComponent();
            ConnectionClient.Connected += (sender, args) => { Text = "Connected!"; };
            Test();
        }

        private void Test()
        {
            Data.Instance.Client = new ConnectionClient(Data.ServerUrl, Data.HubName);
        }

        private void SetTime()
        {
            Text0 = DateTime.Now.ToString("T");
        }
    }
}
