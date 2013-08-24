using System;
using Mosquito.Core.Internal;

namespace Mosquito.Impl
{
    sealed public class CallbackHost : IDisposable
    {
        public void Open(ICallbackProcessor callbackProcessor)
        {
            var callbackChannel = new MosquitoCallbackChannelImpl(callbackProcessor);
            _serviceHost = new System.ServiceModel.ServiceHost(callbackChannel);
            _serviceHost.Open();
        }

        public void Close()
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        private System.ServiceModel.ServiceHost _serviceHost;

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                Close();
            }
        }
    }
}
