using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Xamarin.Forms;

namespace ChatMobile.Views
{
    public partial class MainPage : ContentPage
    {
        //private string _text;
        //public string Text
        //{
        //    get { return _text; }
        //    set
        //    {
        //        _text = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string _text0;
        //public string Text0
        //{
        //    get { return _text0; }
        //    set
        //    {
        //        _text0 = value;
        //        OnPropertyChanged();
        //    }
        //}

        
        public MainPage()
        {
            InitializeComponent();
            Init.Initialize();

            if (XmlActions.Deserialize(XmlActions.SettingsFile, SettingsManager.Instance.Settings) is List<Setting> settings)
            {
                try
                {
                    var setting = settings.Find(stng => stng.Name == Setting.XmlProperty_IsFirstLogin);
                    //todo: happens when already made account
                    //return;
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                XmlActions.Serialize(XmlActions.SettingsFile, SettingsManager.Instance.Settings);
            }


            Data.Instance.Client.Hub.Invoke("SetupDevice", "1", "2");
            //Data.Instance.Client.Hub.On<string>("GetUserId", (userId) => t = userId);
            //var userId = Data.Instance.Client.Hub.Invoke<string>("SetupDevice", "1", "2").Result;

            //SettingsManager.Instance.Add(new Setting("1", "value1"));
            //SettingsManager.Instance.Add(new Setting("2", "value2"));

            //XmlActions.Serialize(XmlActions.SettingsFile, SettingsManager.Instance.Settings);

            //var t = XmlActions.Deserialize(XmlActions.SettingsFile, SettingsManager.Instance.Settings);

            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        SetTime();
            //        //await Task.Delay(50);
            //    }
            //});
            //Text = "Not Connected";
            //ConnectionClient.Connected += (sender, args) => { Text = "Connected!"; };
            //Test();
        }

        //private void Test()
        //{
        //    Data.Instance.Client = new ConnectionClient(Data.ServerUrl, Data.HubName);
        //}

        //private void SetTime()
        //{
        //    Text0 = DateTime.Now.ToString("T");
        //}

        private async Task tt()
        {
            await Task.WhenAll(TaskManager.ReceivingUserIdTasks);
        }
    }
}
