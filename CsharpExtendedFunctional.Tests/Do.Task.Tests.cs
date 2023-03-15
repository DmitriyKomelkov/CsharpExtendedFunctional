namespace CsharpExtendedFunctional.Tests;

public class DoTaskTests
{
    [Fact]
    public async Task DoTask_Success()
    {
        // Arrange
        var testRes = 5;
        var q = 12;

        // Act
        var tr = await q.Do(t => Task.Run(() => { testRes = t; }));

        // Assert
        Assert.Equal(q, tr);
        Assert.Equal(q, testRes);
    }

    [Fact]
    public async Task DoTask1_Success()
    {
        // Arrange
        var testRes = 5;
        var q = 12;

        // Act
        // ReSharper disable once AccessToStaticMemberViaDerivedType
        var tr = await q.Do(t => Task<string>.Run(() => { testRes = t; }));

        // Assert
        Assert.Equal(q, tr);
        Assert.Equal(q, testRes);
    }
}