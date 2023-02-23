using CSharpFunctionalExtensions;

namespace Net.CsharpFunctional.BaseExtensions;

public static partial class TryTransformExtensions
{
    public static async Task<Result<TOut>> TryTransform<TIn, TOut>(this TIn self, Func<TIn, Task<TOut>> mapAsync)
    {
        try
        {
            var result = await mapAsync(self);
            return Result.Success(result);
        }
        catch (Exception e)
        {
            return Result.Failure<TOut>(e.Message);
        }
    }

    public static async Task<Result<TOut>> TryTransform<TIn, TOut>(this Task<TIn> taskSelf, Func<TIn, Task<TOut>> action)
    {
        var self = await taskSelf;

        try
        {
            var result = await action(self);
            return Result.Success(result);
        }
        catch (Exception e)
        {
            return Result.Failure<TOut>(e.Message);
        }
    }
}