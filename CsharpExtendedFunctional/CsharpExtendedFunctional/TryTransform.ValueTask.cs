using CSharpFunctionalExtensions;

namespace Net.CsharpFunctional.BaseExtensions;

public static partial class TryTransformExtensions
{
    public static async Task<Result<TOut>> TryTransform<TIn, TOut>(this TIn self, Func<TIn, ValueTask<TOut>> mapAsync)
    {
        try
        {
            var result = await mapAsync(self);
            return Result.Success<TOut>(result);
        }
        catch (Exception e)
        {
            return Result.Failure<TOut>(e.Message);
        }
    }

    public static async Task<Result<TOut>> TryTransform<TIn, TOut>(this Task<TIn> taskSelf, Func<TIn, ValueTask<TOut>> action)
    {
        var self = await taskSelf;

        try
        {
            var result = await action(self);
            return Result.Success<TOut>(result);
        }
        catch (Exception e)
        {
            return Result.Failure<TOut>(e.Message);
        }
    }
}