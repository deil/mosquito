using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using log4net;
using Mosquito.Core.Bus;
using Mosquito.Core.Internal;

namespace Mosquito.Impl
{
    public class InitiatorBus : IBus
    {
        class OperationWait : IDisposable
        {
            public OperationInvocationInfo Invocation;
            public ManualResetEvent WaitEvent;
            public Message ReceivedReply;

            void IDisposable.Dispose()
            {
                if (!_disposed)
                {
                    _disposed = true;
                    WaitEvent.Dispose();
                }
            }

            private bool _disposed = false;
        }

        public InitiatorBus(IMosquitoChannel channel)
        {
            _channel = channel;
        }

        public Message SendAndWait(Message message)
        {
            using (var invocation = new OperationWait
                                 {
                                     Invocation = new OperationInvocationInfo { Id = message.Id, Parameter = message.Data },
                                     WaitEvent = new ManualResetEvent(false)
                                 })
            {
                lock (_invocations)
                {
                    _invocations.Add(invocation);
                }

                _channel.Invoke(invocation.Invocation);
                invocation.WaitEvent.WaitOne();

                return invocation.ReceivedReply;
            }
        }

        public void SendAndWait(Message message, Action<Message> callback)
        {
            var reply = SendAndWait(message);
            callback(reply);
        }

        public void SendAndWait(Message message, Action callback)
        {
            var reply = SendAndWait(message);
            callback();
        }

        public void Publish(Message message)
        {
            _channel.Invoke(new OperationInvocationInfo {Id = message.Id, Parameter = message.Data});
        }

        public void Receive(Message message)
        {
            lock (_invocations)
            {
                var invocation = _invocations.FirstOrDefault(o => o.Invocation.Id == message.InReplyTo);
                if (invocation != null)
                {
                    _invocations.Remove(invocation);
                    invocation.ReceivedReply = message;
                    invocation.WaitEvent.Set();
                }
            }
        }

        private readonly IMosquitoChannel _channel;
        private readonly IList<OperationWait> _invocations = new List<OperationWait>();
    }
}
