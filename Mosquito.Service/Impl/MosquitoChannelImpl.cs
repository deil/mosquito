using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using log4net;
using Mosquito.Core;
using Mosquito.Core.Internal;

namespace Mosquito.Service.Impl
{
    sealed internal class MosquitoChannelImpl : IMosquitoChannel
    {
        public void SayHello()
        {
            var props = OperationContext.Current.IncomingMessageProperties;
            var remoteEndpoint = (RemoteEndpointMessageProperty) props[RemoteEndpointMessageProperty.Name];
            var remoteIp = remoteEndpoint.Address;

            if (Logger.IsInfoEnabled)
                Logger.InfoFormat("Received hello from {0}", remoteIp);
        }

        public void EnqueueTask(ITask task)
        {
            if (Logger.IsDebugEnabled)
                Logger.DebugFormat("New task: {0}", task.GetType().FullName);
        }

        public void ProcessCommand(ICommand command)
        {
            if (Logger.IsDebugEnabled)
                Logger.DebugFormat("New command: {0}", command.GetType().FullName);
        }

        public void RaiseEvent(IEvent @event)
        {
            if (Logger.IsDebugEnabled)
                Logger.DebugFormat("New event: {0}", @event.GetType().FullName);
        }

        private ILog Logger { get { return LogManager.GetLogger(GetType()); } }
    }
}
