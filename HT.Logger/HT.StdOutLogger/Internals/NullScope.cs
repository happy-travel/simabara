using System;

namespace HT.StdOutLogger.Internals
{
    internal class NullScope : IDisposable
    {
        private NullScope()
        {
        }


        public void Dispose()
        {
        }


        public static NullScope Instance { get; } = new NullScope();
    }
}