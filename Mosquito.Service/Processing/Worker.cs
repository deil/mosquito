using System;
using Castle.Windsor;
using Mosquito.Core;

namespace Mosquito.Service.Processing
{
    sealed internal class Worker
    {
        public Worker(ProcessingQueue queue, HandlersFactory handlersFactory)
        {
            _queue = queue;
            _handlersFactory = handlersFactory;
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
        private readonly HandlersFactory _handlersFactory;

        private void ProcessItem(QueueItem item)
        {
            try
            {
                if (item.Command != null)
                {
                    var result = _handlersFactory.HandleCommand(item.Command, item.ResultType);
                    if (item.CompletionCallback != null)
                    {
                        item.CompletionCallback(result, item.State);
                    }
                }
                else if (item.Event != null)
                {
                    _handlersFactory.HandleEvent(item.Event);
                }
                else if (item.Task != null)
                {
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
