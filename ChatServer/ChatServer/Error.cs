using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ChatServer
{
    public class Error
    {
        [XmlElement] public string SendingUserId;
        [XmlElement] public string ReceivingChatId;
        [XmlElement] public string ErrorMessage;

        public Error() { }

        public Error(string sendingUserId, string receivingChatId, string errorMessage)
        {
            this.SendingUserId = sendingUserId;
            this.ReceivingChatId = receivingChatId;
            this.ErrorMessage = errorMessage;
        }
    }
}