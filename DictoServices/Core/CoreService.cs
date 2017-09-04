using System;
using DictoServices.Interfaces;

namespace DictoServices.Core
{
    public class CoreService : ICoreService
    {
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}