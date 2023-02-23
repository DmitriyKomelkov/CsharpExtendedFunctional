using System;
using CSharpFunctionalExtensions;

namespace CsharpExtendedFunctional
{
    public static partial class TryDoExtensions
    {
        /// <summary>
        /// Execute action with argument of T type it try catch.
        /// If no exceptions happened return success result.
        /// In another case return failure result.
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="self">Arg of T type</param>
        /// <param name="action">Action with arg of T type</param>
        /// <returns>Instance of Result of T type</returns>
        public static Result<T> TryDo<T>(this T self, Action<T> action)
        {
            try
            {
                action(self);
                return Result.Success(self);
            }
            catch (Exception e)
            {
                return Result.Failure<T>(e.Message);
            }
        }
    }
}