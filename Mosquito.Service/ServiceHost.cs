using System;
using Mosquito.Service.Impl;

namespace Mosquito.Service
{
    public class ServiceHost : IDisposable
    {
        public void Open()
        {
            _serviceHost = new System.ServiceModel.ServiceHost(typeof (MosquitoChannelImpl));
            _serviceHost.Open();
        }

        public void Close()
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
            }
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                Close();
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        private System.ServiceModel.ServiceHost _serviceHost;
    }
}

