using System;
using System.ServiceModel;

namespace Mosquito.Core.Internal
{
    [ServiceContract]
    [ServiceKnownType("GetRegisteredCallbackTypes", typeof(KnownTypesProvider))]
    public interface IMosquitoCallbackChannel
    {
        [OperationContract]
        void SayHello();

        [OperationContract]
        void RaiseEvent(IEvent @event);

        [OperationContract]
        void Callback(OperationResult result);
    }
}
