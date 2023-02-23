using System;
using CSharpFunctionalExtensions;

namespace CsharpExtendedFunctional
{

    public static partial class TryDoExtensions
    {
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