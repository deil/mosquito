using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mosquito.Core;

namespace Mosquito.Service.Impl
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
    }
}
