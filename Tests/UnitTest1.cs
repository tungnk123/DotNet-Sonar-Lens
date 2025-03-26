using DotNetSonarLens.Controllers;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void TestGetData()
    {
        var controller = new WeatherForecastController();
        var result = controller.GetData("test");
        Assert.Equal("ok", result);
    }
}