using System;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Mosquito.Core;
using Mosquito.Core.Internal;

namespace Mosquito
{
    sealed public class Mosquito
    {
        public ICommandProcessor CommandProcessor
        {
            get { return _container.Resolve<ICommandProcessor>(); }
        }

        public void RegisterCommand<T>() where T : ICommand
        {
            if (_isStarted)
            {
                throw new ApplicationException("Mosquito is already started. Operation is not permitted");
            }
            else
            {
                KnownTypesProvider.RegisterType<T>();
            }
        }

        public void Start()
        {
            if (_isStarted)
                return;

            _isStarted = true;
            InitContainer();
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
                    Component.For<ICommandProcessor>().ImplementedBy<CommandProcessor>()
                );
        }

        private void OpenCallbackChannel()
        {
            _callbackHost = new CallbackHost();
            _callbackHost.Open();
        }
    }
}
