namespace CsharpExtendedFunctional.Tests;

public class DoTaskTests
{
    [Fact]
    public async Task Do_Task_Success()
    {
        // Arrange
        var testResult = 5;
        var intTypeValue = 12;

        // Act
        var tr = await intTypeValue.Do(t => Task.Run(() => { testResult = t; }));

        // Assert
        Assert.Equal(intTypeValue, tr);
        Assert.Equal(intTypeValue, testResult);
    }

    [Fact]
    public async Task Do_TaskEx_Success()
    {
        // Arrange
        var testRes = 5;
        var intTypeValue = 12;

        // Act
        var tr = await intTypeValue.Do(t => Task.Run(() =>
        {
            testRes = t;
            Task.FromResult("OK");
        }));

        // Assert
        Assert.Equal(intTypeValue, tr);
        Assert.Equal(intTypeValue, testRes);
    }
    
    [Fact]
    public async Task TaskDo_Task_Success()
    {
        // Arrange
        var testRes = 5;
        var taskIntTypeValue = Task.FromResult(12);

        // Act
        var tr = await taskIntTypeValue.Do(t => Task.Run(() =>
        {
            testRes = t;
        }));

        // Assert
        Assert.Equal(await taskIntTypeValue, tr);
        Assert.Equal(await taskIntTypeValue, testRes);
    }
    
    [Fact]
    public async Task TaskDo_TaskEx_Success()
    {
        // Arrange
        var testRes = 5;
        var taskIntTypeValue = Task.FromResult(12);

        // Act
        var tr = await taskIntTypeValue.Do(t => Task.Run(() =>
        {
            testRes = t;
            Task.FromResult("OK");
        }));

        // Assert
        Assert.Equal(await taskIntTypeValue, tr);
        Assert.Equal(await taskIntTypeValue, testRes);
    }
}