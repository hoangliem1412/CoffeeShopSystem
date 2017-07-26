using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Infrastructure
{
    public class Disposable : IDisposable //interface cuar c#. tự động hủy.
    {
        private bool isDisposed;
        ~Disposable()
        {
            Dispose(false);
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //thu hoạch bộ nhớ.
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        //Overide this to dispose custom object
        protected virtual void DisposeCore()
        {

        }
    }
}
