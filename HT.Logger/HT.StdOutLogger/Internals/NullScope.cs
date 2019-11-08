using System;
using System.Collections.Generic;
using System.Text;

namespace StdOutLogger.Internals
{
    internal class NullScope : IDisposable
    {
        private NullScope()
        {}


        public void Dispose()
        {}


        public static NullScope Instance { get; } = new NullScope();
    }
}
