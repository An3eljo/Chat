using System.Xml.Serialization;
using ChatServer.Interfaces;

namespace ChatServer.Errors
{
    public class SendingError : IError
    {
        [XmlElement] public string SendingUserId;
        [XmlElement] public string ReceivingChatId;

        public SendingError() { }

        public SendingError(string sendingUserId, string receivingChatId, string errorMessage)
        {
            this.SendingUserId = sendingUserId;
            this.ReceivingChatId = receivingChatId;
            this.ErrorMessage = errorMessage;
        }
    }
}