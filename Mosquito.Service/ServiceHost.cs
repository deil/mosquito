using System;

namespace Mosquito.Service
{
    public class ServiceHost : IDisposable
    {
        public void Open()
        {
        }

        public void Close()
        {
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
    }
}

