using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Shared;

namespace ChatServer.Interfaces
{
    public abstract class IHub : Hub
    {
        //todo: message model && replace
        //todo: "anweisung" model
        public abstract Task Send(string sendingUserPublicId, int chatIdReceiver, IMessage message);

        public abstract Task<bool> VerifyDevice(string publicUserId, string deviceId);

        public abstract Task JoinGroup(string publicClientId, string publicGroupId);
    }
}
