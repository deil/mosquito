using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Mosquito.Core;
using Mosquito.Core.Internal;

namespace Mosquito.Impl
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal class MosquitoCallbackChannelImpl : IMosquitoCallbackChannel
    {
        public MosquitoCallbackChannelImpl(ICallbackProcessor callbackProcessor)
        {
            _callbackProcessor = callbackProcessor;
        }

        public void SayHello()
        {
            Console.WriteLine("MosquitoCallbackChannelImpl.SayHello() called");
        }

        public void RaiseEvent(IEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Callback(OperationResult result)
        {
            _callbackProcessor.ProcessCallback(result);
        }

        private readonly ICallbackProcessor _callbackProcessor;
    }
}
