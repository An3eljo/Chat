using System;
using System.Collections.Generic;
using System.Text;

namespace ChatMobile
{
    public sealed class Data
    {
        #region Singleton

        private static volatile Data _instance;
        private static object locker = new object();

        private Data() { }

        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        if (_instance == null)
                            _instance = new Data();
                    }
                }

                return _instance;
            }
        }

        #endregion

        public const string ServerUrl = "http://joos.io:9003/signalr/hubs";
        public const string HubName = "MainChatHub";

        public ConnectionClient Client;
    }
}
