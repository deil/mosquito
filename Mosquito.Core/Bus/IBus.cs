using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mosquito.Core.Bus
{
    public interface IBus
    {
        void SendAndWait(Message operation, Action<Message> callback);
        void SendAndWait(Message operation, Action callback);
        void Publish(Message operation);
    }
}
