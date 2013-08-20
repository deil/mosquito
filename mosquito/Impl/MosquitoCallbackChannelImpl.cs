using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Mosquito.Core;
using Mosquito.Core.Internal;

namespace Mosquito.Impl
{
    internal class MosquitoCallbackChannelImpl : IMosquitoCallbackChannel
    {
        public void SayHello()
        {
            Debug.WriteLine("MosquitoCallbackChannelImpl.SayHello() called");
        }

        public void RaiseEvent(IEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
