using System;
using System.Collections.Generic;
using System.Threading;
using Mosquito.Core;
using Mosquito.Core.Internal;
using Mosquito.Service.Impl;

namespace Mosquito.Service.Processing
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

        public void EnqueueCommand(ICommand command, Action<object, object> callback, object state)
        {
            lock (_queue)
            {
                _queue.Enqueue(new QueueItem(command) {CompletionCallback = callback, State = state});
                Monitor.Pulse(_queue);
            }
        }

        public void EnqueueCommand(ICommand command, Type resultType, Action<object, object> callback, object state)
        {
            lock (_queue)
            {
                _queue.Enqueue(new QueueItem(command) {CompletionCallback = callback, ResultType = resultType, State = state});
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
