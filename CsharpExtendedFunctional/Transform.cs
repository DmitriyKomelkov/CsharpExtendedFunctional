using System;

namespace CsharpExtendedFunctional
{
    public static partial class TransformExtensions
    {
        /// <summary>
        /// Execute Func map for transformation arg of TIn into instance of TOut
        /// </summary>
        /// <typeparam name="TIn">Generic input type</typeparam>
        /// <typeparam name="TOut">Generic output type</typeparam>
        /// <param name="self">arg of input type</param>
        /// <param name="map">Func for transformation TIn into TOut</param>
        /// <returns>Instance of TOut</returns>
        public static TOut Transform<TIn, TOut>(this TIn self, Func<TIn, TOut> map) => map(self);
    }
}