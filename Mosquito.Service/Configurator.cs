using System;
using Mosquito.Core;

namespace Mosquito.Service
{
    public class Configurator
    {
        public void RegisterEventHandler<TEvent>(IHandles<TEvent> handler) where TEvent : IEvent
        {
        }

        public void RegisterCommandHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
        }

        public void RegisterTasks(params ITask[] tasks)
        {
        }

        public MosquitoService Build()
        {
            return new MosquitoService();
        }
    }
}

