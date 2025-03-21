using DotNetSonarLens.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DotNetSonarLens.Tests
{
    public class Tests
    {
        [Fact]
        public void TestGetData()
        {
            var controller = new WeatherForecastController();
            var result = controller.GetData("test");
            Assert.Equal("ok", result);
        }
    }
}
