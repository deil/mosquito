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
            KnownTypesProvider.RegisterType<T>();
        }

        public void Start()
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

            /*
            var instance = _container.Resolve<IMosquitoChannel>();
            instance.SayHello();
            _container.Release(instance);
             */
        }
        
        public void Stop()
        {
        }

        private IWindsorContainer _container;
    }
}
