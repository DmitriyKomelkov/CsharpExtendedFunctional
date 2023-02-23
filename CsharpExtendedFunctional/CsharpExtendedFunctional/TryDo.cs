using CSharpFunctionalExtensions;

namespace Net.CsharpFunctional.BaseExtensions;

public static partial class TryDoDoExtensions
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