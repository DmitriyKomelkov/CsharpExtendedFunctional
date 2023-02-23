#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CsharpExtendedFunctional
{
    public static partial class TransformExtensions
    {
        /// <summary>
        /// Execute async Func map for transformation arg of TIn into ValueTask of TOut
        /// </summary>
        /// <typeparam name="TIn">Generic input type</typeparam>
        /// <typeparam name="TOut">Generic output type</typeparam>
        /// <param name="self">arg of input type</param>
        /// <param name="map">Func for transformation TIn into ValueTask of TOut</param>
        /// <returns>Task of TOut</returns>
        public static async Task<TOut> Transform<TIn, TOut>(this TIn self, Func<TIn, ValueTask<TOut>> map) =>
            await map(self);

        /// <summary>
        /// Execute async Func map for transformation arg of TIn into ValueTask of TOut
        /// </summary>
        /// <typeparam name="TIn">Generic input type</typeparam>
        /// <typeparam name="TOut">Generic output type</typeparam>
        /// <param name="taskSelf">Task of input type</param>
        /// <param name="map">Func for transformation TIn into ValueTask of TOut</param>
        /// <returns>Task of TOut</returns>
        public static async Task<TOut> Transform<TIn, TOut>(this Task<TIn> taskSelf, Func<TIn, ValueTask<TOut>> map)
        {
            var self = await taskSelf;
            return await map(self);
        }
    }
}
#endif