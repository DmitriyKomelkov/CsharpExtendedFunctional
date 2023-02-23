using CSharpFunctionalExtensions;

namespace Net.CsharpFunctional.BaseExtensions;

public static partial class TryTransformExtensions
{
    public static Result<TOut> TryTransform<TIn, TOut>(this TIn self, Func<TIn, TOut> map)
    {
        try
        {
            var result = map(self);
            return Result.Success(result);
        }
        catch (Exception e)
        {
            return Result.Failure<TOut>(e.Message);
        }

    }
}