using System;
using System.Threading;
using Castle.Windsor;
using log4net;
using Mosquito.Service.Impl;

namespace Mosquito.Service
{
    sealed public class MosquitoService
    {
        public MosquitoService(IWindsorContainer container)
        {
            _container = container;
        }

        public IWindsorContainer Container { get { return _container; } }

        public ProcessingQueue Queue { get { return _queue; } }

        public void Start()
        {
            if (Logger.IsDebugEnabled)
                Logger.Debug("Opening service host");

            _serviceHost = new ServiceHost(this);
            _serviceHost.Open();

            _worker = new Thread(() => new QueueWorker(_queue, _container).Start());
            _worker.Start();

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
        private readonly ProcessingQueue _queue = new ProcessingQueue();
        private Thread _worker;
    }
}

