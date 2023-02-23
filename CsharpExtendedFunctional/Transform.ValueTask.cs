namespace Net.CsharpFunctional.BaseExtensions;

public static partial class TransformExtensions
{
    public static async Task<TOut> Transform<TIn, TOut>(this TIn self, Func<TIn, ValueTask<TOut>> map) => await map(self);
    public static async Task<TOut> Transform<TIn, TOut>(this Task<TIn> taskSelf, Func<TIn, ValueTask<TOut>> map)
    {
        var self = await taskSelf;
        return await map(self);
    }
}