namespace CsharpExtendedFunctional.Tests;

public class DoTests
{
    [Fact]
    public void Do_Success()
    {
        // Arrange
        var testRes = 5;
        var q = 12;

        // Act
        var tr = q.Do(t => testRes = t + 1);

        // Assert
        Assert.Equal(q, tr);
        Assert.Equal(q + 1, testRes);
    }
}