using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Infrastructure
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
