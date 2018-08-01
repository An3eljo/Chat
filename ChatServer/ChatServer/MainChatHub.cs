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
        public override async Task Send(int clientIdSender, int chatIdReceiver, string message)
        {
            
        }

        public override async Task  JoinGroup(int clientId, int groupId)
        {
            Task.Factory.StartNew(() =>
            {
                var db = new ChatEntities1();

                var userGroup = new Users_Groups
                {
                    Fk_User = clientId,
                    Fk_Group = groupId
                };

                db.Users_Groups.Add(userGroup);
                db.SaveChangesAsync();
            }).Start();
            
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}