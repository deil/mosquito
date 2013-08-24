using System;
using Mosquito.Core;

namespace Mosquito.Service.Processing
{
    sealed public class QueueItem
    {
        public QueueItem(ITask task)
        {
            Task = task;
        }

        public QueueItem(ICommand command)
        {
            Command = command;
        }

        public QueueItem(IEvent @event)
        {
            Event = @event;
        }

        public readonly ITask Task;
        public readonly ICommand Command;
        public readonly IEvent Event;
        public Action<object, object> CompletionCallback;
        public object State;
        public Type ResultType;
    }
}
