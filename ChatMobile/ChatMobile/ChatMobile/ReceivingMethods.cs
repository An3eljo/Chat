using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.SignalR.Client;

namespace ChatMobile
{
    public class ReceivingMethods
    {
        public static EventHandler ReceiveUserId;

        public static void Initialize()
        {
            Data.Instance.Client.Hub.On<string>("OnReceiveUserId", userId =>
            {
                //TaskManager.ReceivingUserIdTasks[0].
                //ReceiveUserId.Invoke(null, EventArgs.Empty);
            });
        }
    }
}
