using System;

namespace CsharpExtendedFunctional
{
    public static partial class UsingExtensions
    {
        public static TOut Using<TIn, TOut>(this TIn self, Func<TIn, TOut> map) where TIn : IDisposable
        {
            var result = map(self);
            self.Dispose();
            return result;
        }
    }
}