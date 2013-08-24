using System;
using System.ServiceModel;

namespace Mosquito.Core.Internal
{
    [ServiceContract]
    [ServiceKnownType("GetRegisteredTypes", typeof(KnownTypesProvider))]
    public interface IMosquitoChannel
    {
        [OperationContract]
        void SayHello();

        [OperationContract]
        void EnqueueTask(ITask task);

        [OperationContract]
        void ProcessCommand(ICommand command);

        [OperationContract]
        void Invoke(OperationInvocationInfo operation);

        [OperationContract]
        void RaiseEvent(IEvent @event);
    }
}
