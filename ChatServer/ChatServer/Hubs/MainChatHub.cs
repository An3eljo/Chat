using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Shared;
using IHub = ChatServer.Interfaces.IHub;

namespace ChatServer.Hubs
{
    [HubName("MainChatHub")]
    public class MainChatHub : IHub
    {
        public override async Task Send(int chatIdReceiver, IMessage message)
        {
            var db = new ChatEntities1();
            var receiver = db.Groups.FirstOrDefault(chat => chat.Id == chatIdReceiver);

            if (receiver == null)
            {
#pragma warning disable 4014
                Task.Run(async () => { await XmlActions.Serialize("", new Error());});
#pragma warning restore 4014
            }
        }

        public override async Task JoinGroup(int clientId, int groupId)
        {
            var db = new ChatEntities1();

            var userGroup = new Users_Groups
            {
                Fk_User = clientId,
                Fk_Group = groupId
            };

            db.Users_Groups.Add(userGroup);
            await db.SaveChangesAsync();
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