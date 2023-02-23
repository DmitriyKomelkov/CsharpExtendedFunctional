namespace CsharpExtendedFunctional
{
    public static partial class TransformExtensions
    {
        /// <summary>
        /// Execute async Func map for transformation arg of TIn into Task of TOut
        /// </summary>
        /// <typeparam name="TIn">Generic input type</typeparam>
        /// <typeparam name="TOut">Generic output type</typeparam>
        /// <param name="self">arg of input type</param>
        /// <param name="map">Func for transformation TIn into Task of TOut</param>
        /// <returns>Task of TOut</returns>
        public static async Task<TOut> Transform<TIn, TOut>(this TIn self, Func<TIn, Task<TOut>> map) =>
            await map(self);

        /// <summary>
        /// Get param with type TIn (async) from Task.
        /// Execute async Func map for transformation arg of TIn into Task of TOut
        /// </summary>
        /// <typeparam name="TIn">Generic input type</typeparam>
        /// <typeparam name="TOut">Generic output type</typeparam>
        /// <param name="taskSelf">Task of input type</param>
        /// <param name="map">Func for transformation TIn into Task of TOut</param>
        /// <returns>Task of TOut</returns>
        public static async Task<TOut> Transform<TIn, TOut>(this Task<TIn> taskSelf, Func<TIn, Task<TOut>> map)
        {
            var self = await taskSelf;
            return await map(self);
        }
    }
}