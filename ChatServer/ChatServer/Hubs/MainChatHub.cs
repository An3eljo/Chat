using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Shared;
using ChatServer.Errors;
using ChatServer.Library;
using IHub = ChatServer.Interfaces.IHub;

namespace ChatServer.Hubs
{
    [HubName("MainChatHub")]
    public class MainChatHub : IHub
    {
        public override async Task Send(string sendingUserPublicId, int chatIdReceiver, IMessage message)
        {
            var db = new ChatEntities1();
            var receiver = db.Groups.FirstOrDefault(chat => chat.Id == chatIdReceiver);

            if (receiver == null)
            {
                string sendingUserid = null;

                try
                {
                    sendingUserid = db.Users.First(user => user.PublicId == sendingUserid).Id.ToString();
                }
                catch
                {
                    sendingUserid = String.Empty;
                }

#pragma warning disable 4014
                Task.Run(async () =>
                {
                    await XmlActions.Serialize(XmlActions.ErrorMessagesPath,
                        new SendingError(sendingUserid, chatIdReceiver.ToString(),
                            Errors.Errors.Instance.GetErrorMessage("Error_ReceiverChatIdNull")));
                });
#pragma warning restore 4014
                return;
            }

            if (receiver.IsMultiUserChat)
            {
                var groupname = db.Groups.First(grp => grp.PublicId == chatIdReceiver.ToString()).Id.ToString();
                Clients.OthersInGroup(groupname).Receive(sendingUserPublicId, message);
            }
            else
            {
                
            }
        }

        public Task SetupDevice(string deviceId, string username)
        {
            var db = new ChatEntities1();
            var userId = IdCreator.CreateId();
            var user = new Users()
            {
                DeviceId = deviceId,
                Username = username,
                LastSignalrId = Context.ConnectionId,
                PublicId = userId,
                IsAuthenticated = true
            };

            db.Users.Add(user);
            db.SaveChanges();
            //await db.SaveChangesAsync();
            //Clients.Caller.GetUserId(userId);

            //return new Task<string>(() => userId);
            return new Task(() => {});
        }

        public async Task Login(string publicUserId, string deviceId)
        {
            var db = new ChatEntities1();

            var isAuthenticated = await Task.Run(() => VerifyDevice(publicUserId, deviceId));
            if (isAuthenticated)
            {
                db.Users.First(usr => usr.PublicId == publicUserId).LastSignalrId = Context.ConnectionId;
                db.Users.First(usr => usr.PublicId == publicUserId).IsAuthenticated = true;
                db.SaveChanges();
            }
        }

        public override Task<bool> VerifyDevice(string publicUserId, string deviceId)
        {
            var db = new ChatEntities1();
            var user = db.Users.First(usr => usr.PublicId == publicUserId && usr.DeviceId == deviceId);
            if (user != null)
            {
                return new Task<bool>(() => true);
            }

            return new Task<bool>(() => false);
        }

        public override async Task JoinGroup(string publicClientId, string publicGroupId)
        {
            //var db = new ChatEntities1();

            //var userGroup = new Users_Groups
            //{
            //    Fk_User = publicClientId,
            //    Fk_Group = publicGroupId
            //};

            //db.Users_Groups.Add(userGroup);
            //await db.SaveChangesAsync();
        }

        public override Task OnConnected()
        { 
            var db = new ChatEntities1();
            
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