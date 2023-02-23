using CSharpFunctionalExtensions;

namespace Net.CsharpFunctional.BaseExtensions;

public static partial class TryDoExtensions
{
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