using DotNetSonarLens.Controllers;

namespace Tests;

public class Tests
{
    [Fact]
    public void TestGetData()
    {
        var controller = new CodeAnalysisController();
        var result = controller.GetData("test");
        Assert.Equal("OK", result, true);
    }
}