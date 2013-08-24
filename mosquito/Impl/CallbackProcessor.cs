using Mosquito.Core.Bus;
using Mosquito.Core.Internal;

namespace Mosquito.Impl
{
    public class CallbackProcessor : ICallbackProcessor
    {
        public CallbackProcessor(InitiatorBus bus)
        {
            _bus = bus;
        }

        public void ProcessCallback(OperationResult result)
        {
            _bus.Receive(new Message {InReplyTo = result.OperationId, Data = result.Result});
        }

        private readonly InitiatorBus _bus;
    }
}
