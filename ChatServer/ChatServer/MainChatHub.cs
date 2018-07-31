using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ChatServer.Interfaces;

namespace ChatServer
{
    public class MainChatHub : IHub
    {
        public override void Send(int clientId, int clientIdReceiver, string message)
        {
            
        }
    }
}