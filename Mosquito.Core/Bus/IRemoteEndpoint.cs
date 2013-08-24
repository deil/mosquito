using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mosquito.Core.Bus
{
    public interface IRemoteEndpoint
    {
        void ReceiveAndReply(Message message);
        void Receive(Message message);
    }
}
