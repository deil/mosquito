using System;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Mosquito.Core;
using Mosquito.Core.Bus;
using Mosquito.Core.Internal;
using Mosquito.Impl;

namespace Mosquito
{
    sealed public class Mosquito
    {
        public ICommandProcessor CommandProcessor
        {
            get { return _container.Resolve<ICommandProcessor>(); }
        }

        public void RegisterCommand<TCommand, TResult>() where TCommand : ICommand
        {
            if (_isStarted)
            {
                throw new ApplicationException("Mosquito is already started. Operation is not permitted");
            }
            else
            {
                KnownTypesProvider.RegisterType<TCommand>();
                KnownTypesProvider.RegisterCallbackType<TResult>();
            }
        }

        public void Start()
        {
            if (_isStarted)
                return;

            _isStarted = true;
            InitContainer();

            _bus = new InitiatorBus(_container.Resolve<IMosquitoChannel>());
            _container.Register(Component.For<IBus>().Instance(_bus));

            OpenCallbackChannel();
        }
        
        public void Stop()
        {
            if (_callbackHost != null)
            {
                _callbackHost.Close();
            }

            _isStarted = false;
        }

        private bool _isStarted;
        private IWindsorContainer _container;
        private InitiatorBus _bus;
        private CallbackHost _callbackHost;

        private void InitContainer()
        {
            _container = new WindsorContainer();
            _container
                .AddFacility<WcfFacility>()
                .Register(
                    Component
                        .For<IMosquitoChannel>()
                        .AsWcfClient(WcfEndpoint.FromConfiguration("NetTcpBinding_IMosquitoChannel")),
                    Component.For<ICommandProcessor>().ImplementedBy<CommandProcessor>().Forward<ICallbackProcessor>()
                );
        }

        private void OpenCallbackChannel()
        {
            _callbackHost = new CallbackHost();
            _callbackHost.Open(new CallbackProcessor(_bus));
        }
    }
}
