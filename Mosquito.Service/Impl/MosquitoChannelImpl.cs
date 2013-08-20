using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Mosquito.Core;
using Mosquito.Core.Internal;

namespace Mosquito.Service.Impl
{
    internal class MosquitoChannelImpl : IMosquitoChannel
    {
        public void SayHello()
        {
            Console.WriteLine("MosquitoChannelImpl.SayHello() called");
        }

        public void EnqueueTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public void ProcessCommand(ICommand command)
        {
            throw new NotImplementedException();
        }

        public void RaiseEvent(IEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
