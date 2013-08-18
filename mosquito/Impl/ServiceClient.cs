using System;

namespace Mosquito
{
    public class ServiceClient : IDisposable
    {
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
