using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Mosquito.Core;

namespace Mosquito.Service.Impl
{
    sealed public class ProcessingQueue
    {
        public void EnqueueTask(ITask task)
        {
            lock (_queue)
            {
                _queue.Enqueue(new QueueItem(task));
                Monitor.Pulse(_queue);
            }
        }

        public void EnqueueCommand(ICommand command)
        {
            lock (_queue)
            {
                _queue.Enqueue(new QueueItem(command));
                Monitor.Pulse(_queue);
            }
        }

        public void EnqueueEvent(IEvent @event)
        {
            lock (_queue)
            {
                _queue.Enqueue(new QueueItem(@event));
                Monitor.Pulse(_queue);
            }
        }

        public QueueItem DequeueItem()
        {
            lock (_queue)
            {
                while (true)
                {
                    if (_queue.Count > 0)
                        return _queue.Dequeue();

                    Monitor.Wait(_queue);
                }
            }
        }

        private readonly Queue<QueueItem> _queue = new Queue<QueueItem>();
    }
}
