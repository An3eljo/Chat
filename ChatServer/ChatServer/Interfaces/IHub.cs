using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ChatServer.Interfaces
{
    public abstract class IHub : Hub
    {
        //todo: message model
        //todo: "anweisung" model
        public abstract void Send(int clientIdSender, int chatIdReceiver, Message message);
        public void JoinGroup(int clientId, int groupId)
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
    }
}
