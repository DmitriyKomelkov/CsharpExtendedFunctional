using System;
using System.Threading.Tasks;

namespace CsharpExtendedFunctional
{

    public static partial class UsingExtensions
    {
        public static async Task<TOut> Using<TIn, TOut>(this TIn self, Func<TIn, Task<TOut>> map)
            where TIn : IDisposable
        {
            var result = await map(self);
            self.Dispose();
            return result;
        }
    }
}