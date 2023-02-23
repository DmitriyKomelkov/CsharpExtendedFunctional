﻿namespace Net.CsharpFunctional.BaseExtensions;

public static partial class UsingExtensions
{
    public static async Task<TOut> Using<TIn, TOut>(this TIn self, Func<TIn, ValueTask<TOut>> map) where TIn : IDisposable
    {
        var result = await map(self);
        self.Dispose();
        return result;
    }
}