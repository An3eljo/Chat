using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public abstract class IMessage
    {
        public DateTime SendTime;
        public Type MessageType;
    }
}
