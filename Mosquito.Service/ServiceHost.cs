using System;
using Mosquito.Core.Internal;
using Mosquito.Service.Impl;

namespace Mosquito.Service
{
    public class ServiceHost : IDisposable
    {
        public ServiceHost(MosquitoService owner)
        {
            _owner = owner;
        }

        public void Open()
        {
            var channel = new MosquitoChannelImpl(_owner.Container);
            _serviceHost = new System.ServiceModel.ServiceHost(channel);
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

        private readonly MosquitoService _owner;
        private System.ServiceModel.ServiceHost _serviceHost;
    }
}

