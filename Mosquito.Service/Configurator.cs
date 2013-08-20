using System;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Mosquito.Core;
using Mosquito.Core.Internal;
using Mosquito.Service.Impl;

namespace Mosquito.Service
{
    public class Configurator
    {
        public Configurator()
        {
        }

        public void RegisterEventHandler<TEvent>(IHandles<TEvent> handler) where TEvent : IEvent
        {
        }

        public void RegisterCommandHandler<TCommand, THandler>() where TCommand : ICommand where THandler : ICommandHandler<TCommand>
        {
            KnownTypesProvider.RegisterType<TCommand>();
        }

        public void RegisterTasks(params ITask[] tasks)
        {
        }

        public MosquitoService Build()
        {
            return new MosquitoService(_container);
        }

        private readonly IWindsorContainer _container = new WindsorContainer();
    }
}
