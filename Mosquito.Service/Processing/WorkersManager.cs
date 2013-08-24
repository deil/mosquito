using System.Collections.Generic;
using System.Threading;

namespace Mosquito.Service.Processing
{
    internal class WorkersManager
    {
        public WorkersManager(ProcessingQueue queue, HandlersFactory handlersFactory)
        {
            _queue = queue;
            _handlersFactory = handlersFactory;
        }

        public bool IsRunning { get; private set; }

        public void Run()
        {
            IsRunning = true;

            var worker = CreateWorker();
            _workers.Add(worker);
            new Thread((obj) => ((Worker)obj).Start()).Start(worker);
        }

        public void Stop()
        {
            IsRunning = false;
        }

        #region private

        private readonly ProcessingQueue _queue;
        private readonly HandlersFactory _handlersFactory;
        private readonly IList<Worker> _workers = new List<Worker>();

        private Worker CreateWorker()
        {
            return new Worker(_queue, _handlersFactory);
        }

        #endregion
    }
}
