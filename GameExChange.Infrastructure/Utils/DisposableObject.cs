using System;

namespace GameExChange.Infrastructure.Utils
{
    public abstract class DisposableObject : IDisposable
    {
        ~DisposableObject()
        {
            this.Dispose(false);
        }

        protected abstract void Dispose(bool disposing);

        protected void ExplicitDispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose()
        {
            this.ExplicitDispose();
        }
    }
}
