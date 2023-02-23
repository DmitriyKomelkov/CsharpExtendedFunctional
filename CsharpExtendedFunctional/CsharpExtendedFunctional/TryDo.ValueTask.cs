using CSharpFunctionalExtensions;

namespace Net.CsharpFunctional.BaseExtensions;

public static partial class TryDoExtensions
{
    public static async Task<Result<T>> TryDo<T>(this T self, Func<T, ValueTask> action)
    {
        try
        {
            await action(self);
            return Result.Success<T>(self);
        }
        catch (Exception e)
        {
            return Result.Failure<T>(e.Message);
        }
    }

    public static async Task<Result<T>> TryDo<T, TEx>(this T self, Func<T, ValueTask<TEx>> action)
    {
        try
        {
            await action(self);
            return Result.Success<T>(self);
        }
        catch (Exception e)
        {
            return Result.Failure<T>(e.Message);
        }
    }

    public static async Task<Result<T>> TryDo<T>(this Task<T> taskSelf, Func<T, ValueTask> action)
    {
        var self = await taskSelf;

        try
        {
            await action(self);
            return Result.Success<T>(self);
        }
        catch (Exception e)
        {
            return Result.Failure<T>(e.Message);
        }
    }

    public static async Task<Result<T>> TryDo<T, TEx>(this Task<T> taskSelf, Func<T, ValueTask<TEx>> action)
    {
        var self = await taskSelf;

        try
        {
            await action(self);
            return Result.Success<T>(self);
        }
        catch (Exception e)
        {
            return Result.Failure<T>(e.Message);
        }
    }
}