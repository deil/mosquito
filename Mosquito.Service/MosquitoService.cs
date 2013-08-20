using System;
using Castle.Windsor;

namespace Mosquito.Service
{
    sealed public class MosquitoService
    {
        public MosquitoService(IWindsorContainer container)
        {
            _container = container;
        }

        public void Start()
        {
            _serviceHost = new ServiceHost();
            _serviceHost.Open();
        }

        public void Stop()
        {
            _serviceHost.Close();
        }

        private readonly IWindsorContainer _container;
        private ServiceHost _serviceHost;
    }
}

