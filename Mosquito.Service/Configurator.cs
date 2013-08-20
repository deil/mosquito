using System;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using log4net;
using Mosquito.Core;
using Mosquito.Core.Internal;
using Mosquito.Service.Impl;

namespace Mosquito.Service
{
    public class Configurator
    {
        public Configurator()
        {
            _container.AddFacility<WcfFacility>()
                .Register(
                    Component
                        .For<IMosquitoCallbackChannel>()
                        .AsWcfClient(WcfEndpoint.FromConfiguration("NetTcpBinding_IMosquitoCallbackChannel"))
                );
        }

        public void RegisterEventHandler<TEvent>(IHandles<TEvent> handler) where TEvent : IEvent
        {
        }

        public void RegisterCommandHandler<TCommand, THandler>() where TCommand : ICommand where THandler : ICommandHandler<TCommand>
        {
            if (Logger.IsDebugEnabled)
                Logger.DebugFormat("Registering handler: {0} for command {1}", typeof(THandler).FullName, typeof(TCommand).FullName);

            KnownTypesProvider.RegisterType<TCommand>();
            _container.Register(
                Component.For<ICommandHandler<TCommand>>().ImplementedBy<THandler>()
            );
        }

        public void RegisterTasks(params ITask[] tasks)
        {
        }

        public MosquitoService Build()
        {
            if (Logger.IsDebugEnabled)
                Logger.Debug("Building Mosquito service");

            return new MosquitoService(_container);
        }

        private ILog Logger { get { return LogManager.GetLogger(GetType()); } }

        private readonly IWindsorContainer _container = new WindsorContainer();
    }
}
