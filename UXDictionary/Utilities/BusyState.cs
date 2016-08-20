using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UXDictionary.Utilities
{
    public sealed class BusyState
    {
        class DisposableExecution : IDisposable
        {
            Action begin;
            Action end;

            public DisposableExecution(Action begin, Action end)
            {
                this.begin = begin;
                this.end = end;

                //
                begin?.Invoke();
            }

            public void Dispose()
            {
                end?.Invoke();
            }
        }

        public static IDisposable Begin(Action begin, Action end)
        {
            return new DisposableExecution(begin, end);
        }

        public static IDisposable Begin(Action end)
        {
            return Begin(null, end);
        }
    }
}
