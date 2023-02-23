using System;

namespace CsharpExtendedFunctional
{
    public static partial class DoExtensions
    {
        /// <summary>
        /// Execute action with argument of T type.
        /// It does not care about executed result, just Do it
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="self">Arg of T type</param>
        /// <param name="action">Action with arg of T type</param>
        /// <returns>Instance of T</returns>
        public static T Do<T>(this T self, Action<T> action)
        {
            action(self);
            return self;
        }
    }
}

