#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CsharpExtendedFunctional
{
    public static partial class DoExtensions
    {
        /// <summary>
        /// Execute async action with argument of T type.
        /// It does not care about executed result, just Do it (async)
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="self">arg of T type</param>
        /// <param name="action">Func with T arg, returns ValueTask</param>
        /// <returns>Task of T type</returns>
        public static async Task<T> Do<T>(this T self, Func<T, ValueTask> action)
        {
            await action(self);
            return self;
        }

        /// <summary>
        /// Execute async action with argument of T type.
        /// It does not care about executed result, just Do it (async)
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <typeparam name="TEx">Generic external type, func action returns ValueTask of it</typeparam>
        /// <param name="self">arg of T type</param>
        /// <param name="action">Func with T arg, returns ValueTask of TEx type</param>
        /// <returns>Task of T type</returns>
        public static async Task<T> Do<T, TEx>(this T self, Func<T, ValueTask<TEx>> action)
        {
            await action(self);
            return self;
        }

        /// <summary>
        /// Get param with type T (async) from Task.
        /// Execute async action with argument of T type (got in previous).
        /// It does not care about executed result, just Do it (async)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="taskSelf">Task of T type</param>
        /// <param name="action">Func with T arg, returns ValueTask</param>
        /// <returns>Task of T type</returns>
        public static async Task<T> Do<T>(this Task<T> taskSelf, Func<T, ValueTask> action)
        {
            var self = await taskSelf;
            await action(self);
            return self;
        }

        /// <summary>
        /// Get param with type T (async) from Task.
        /// Execute async action with argument of T type (got in previous).
        /// It does not care about executed result, just Do it (async)
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <typeparam name="TEx">Generic external type, func action returns ValueTask of it</typeparam>
        /// <param name="taskSelf">Task of T type</param>
        /// <param name="action">Func with T arg, returns Task of TEx type</param>
        /// <returns>Task of T type</returns>
        public static async Task<T> Do<T, TEx>(this Task<T> taskSelf, Func<T, ValueTask<TEx>> action)
        {
            var self = await taskSelf;
            await action(self);
            return self;
        }
    }
}
#endif

