using System;
using System.Collections.Generic;
using System.Threading;
using Castle.Windsor;
using log4net;
using Mosquito.Service.Impl;
using Mosquito.Service.Processing;

namespace Mosquito.Service
{
    sealed public class MosquitoService
    {
        public MosquitoService(IWindsorContainer container)
        {
            _container = container;

            _queue = new ProcessingQueue();
            _workers = new WorkersManager(_queue, new HandlersFactory(_container));
        }

        public IWindsorContainer Container { get { return _container; } }

        public ProcessingQueue Queue { get { return _queue; } }

        public void Start()
        {
            if (Logger.IsDebugEnabled)
                Logger.Debug("Opening service host");

            _serviceHost = new ServiceHost(this);
            _serviceHost.Open();

            _workers.Run();

            if (Logger.IsInfoEnabled)
                Logger.Info("Mosquito service was successfully started");
        }

        public void Stop()
        {
            _serviceHost.Close();
            _workers.Stop();
        }

        #region private

        private ILog Logger { get { return LogManager.GetLogger(GetType()); } }

        private readonly IWindsorContainer _container;
        private ServiceHost _serviceHost;
        private readonly ProcessingQueue _queue;
        private readonly WorkersManager _workers;
        
        #endregion
    }
}

