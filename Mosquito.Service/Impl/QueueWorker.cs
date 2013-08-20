using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.Windsor;
using Mosquito.Core;

namespace Mosquito.Service.Impl
{
    sealed internal class QueueWorker
    {
        public QueueWorker(ProcessingQueue queue, IWindsorContainer container)
        {
            _queue = queue;
            _container = container;
        }

        public void Start()
        {
            while (true)
            {
                var item = _queue.DequeueItem();
                if (item != null)
                {
                    ProcessItem(item);
                }
            }
        }

        private readonly ProcessingQueue _queue;
        private readonly IWindsorContainer _container;

        private void ProcessItem(QueueItem item)
        {
            try
            {
                if (item.Command != null)
                {
                    var handlerType = typeof (ICommandHandler<>).MakeGenericType(item.Command.GetType());
                    var handlers = _container.ResolveAll(handlerType);
                    foreach (var handler in handlers)
                    {
                        var handleMethod = handler.GetType().GetMethod("Handle");
                        handleMethod.Invoke(handler, new[] {item.Command});
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
