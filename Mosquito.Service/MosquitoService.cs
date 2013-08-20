using System;
using Castle.Windsor;
using log4net;

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
            if (Logger.IsDebugEnabled)
                Logger.Debug("Opening service host");

            _serviceHost = new ServiceHost();
            _serviceHost.Open();

            if (Logger.IsInfoEnabled)
                Logger.Info("Mosquito service was successfully started");
        }

        public void Stop()
        {
            _serviceHost.Close();
        }

        private ILog Logger { get { return LogManager.GetLogger(GetType()); } }

        private readonly IWindsorContainer _container;
        private ServiceHost _serviceHost;
    }
}

