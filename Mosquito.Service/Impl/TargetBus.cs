using System;
using System.Reflection;
using Mosquito.Core;
using Mosquito.Core.Bus;
using Mosquito.Core.Internal;
using Mosquito.Service.Processing;

namespace Mosquito.Service.Impl
{
    public class TargetBus : IRemoteEndpoint
    {
        public TargetBus(IMosquitoCallbackChannel callbackChannel, ProcessingQueue queue)
        {
            _callbackChannel = callbackChannel;
            _queue = queue;
        }

        public void ReceiveAndReply(Message message)
        {
            var operation = (Mosquito.Core.Processing.Operation) message.Data;
            switch (operation.Type)
            {
                case Mosquito.Core.Processing.OperationType.Command:
                    if (!string.IsNullOrEmpty(operation.OutputTypeName))
                    {
                        var outputType = Type.GetType(operation.OutputTypeName);
                        _queue.EnqueueCommand((ICommand) operation.Input, outputType, Callback, message.Id);
                    }
                    else
                    {
                        _queue.EnqueueCommand((ICommand) operation.Input, Callback, message.Id);
                    }
                    break;

            }
        }

        public void Receive(Message message)
        {
            return;
        }

        private readonly IMosquitoCallbackChannel _callbackChannel;
        private readonly ProcessingQueue _queue;

        private void Callback(object result, object state)
        {
            _callbackChannel.Callback(new OperationResult {OperationId = (Guid) state, Result = result});
        }
    }
}
