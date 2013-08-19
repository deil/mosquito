using System;
using System.ServiceModel;

namespace Mosquito.Core.Internal
{
    [ServiceContract]
    public interface IMosquitoCallbackChannel
    {
        [OperationContract]
        void RaiseEvent(IEvent @event);
    }
}
