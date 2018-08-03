using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ChatServer.Interfaces
{
    public abstract class IError
    {
        [XmlElement] public string ErrorMessage;
    }
}