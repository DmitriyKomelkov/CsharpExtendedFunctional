using System;
using System.Threading.Tasks;

#if NET5_0_OR_GREATER
namespace CsharpExtendedFunctional
{

    public static partial class UsingExtensions
    {
        public static async Task<TOut> Using<TIn, TOut>(this TIn self, Func<TIn, ValueTask<TOut>> map)
            where TIn : IDisposable
        {
            var result = await map(self);
            self.Dispose();
            return result;
        }
    }
}
#endif