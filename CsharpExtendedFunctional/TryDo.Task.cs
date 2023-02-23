using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace CsharpExtendedFunctional
{
    public static partial class TryDoExtensions
    {
        /// <summary>
        /// Execute async action with argument of T type it try catch.
        /// If no exceptions happened return success result.
        /// In another case return failure result. 
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="self">Arg of T type</param>
        /// <param name="action">Func with arg of T type returns Task</param>
        /// <returns>Instance of Result of T type</returns>
        public static async Task<Result<T>> TryDo<T>(this T self, Func<T, Task> action)
        {
            try
            {
                await action(self);
                return Result.Success(self);
            }
            catch (Exception e)
            {
                return Result.Failure<T>(e.Message);
            }
        }

        /// <summary>
        /// Execute async action with argument of T type it try catch.
        /// If no exceptions happened return success result.
        /// In another case return failure result.  
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <typeparam name="TEx">Generic external type, func action returns Task of it</typeparam>
        /// <param name="self">arg of T type</param>
        /// <param name="action">Func with T arg, returns Task of TEx type</param>
        /// <returns>Instance of Result of T type</returns>
        public static async Task<Result<T>> TryDo<T, TEx>(this T self, Func<T, Task<TEx>> action)
        {
            try
            {
                await action(self);
                return Result.Success(self);
            }
            catch (Exception e)
            {
                return Result.Failure<T>(e.Message);
            }
        }

        public static async Task<Result<T>> TryDo<T>(this Task<T> taskSelf, Func<T, Task> action)
        {
            var self = await taskSelf;

            try
            {
                await action(self);
                return Result.Success(self);
            }
            catch (Exception e)
            {
                return Result.Failure<T>(e.Message);
            }
        }

        public static async Task<Result<T>> TryDo<T, TEx>(this Task<T> taskSelf, Func<T, Task<TEx>> action)
        {
            var self = await taskSelf;

            try
            {
                await action(self);
                return Result.Success(self);
            }
            catch (Exception e)
            {
                return Result.Failure<T>(e.Message);
            }
        }
    }
}