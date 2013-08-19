using System;
using System.ServiceModel;

namespace Mosquito.Core.Internal
{
    [ServiceContract]
    public interface IMosquitoChannel
    {
        [OperationContract]
        void EnqueueTask(ITask task);

        [OperationContract]
        void ProcessCommand(ICommand command);

        [OperationContract]
        void RaiseEvent(IEvent @event);
    }
}
