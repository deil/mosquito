using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mosquito.Impl;

namespace Mosquito
{
    sealed public class CallbackHost : IDisposable
    {
        public void Open()
        {
            _serviceHost = new System.ServiceModel.ServiceHost(typeof(MosquitoCallbackChannelImpl));
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
