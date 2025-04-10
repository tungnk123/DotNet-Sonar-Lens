using Microsoft.AspNetCore.Mvc;

namespace DotNetSonarLens.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger = null)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("test", Name = "GetTestData")]
        public string GetData(string input)
        {
            if (input == null) // Bug tiềm ẩn: không xử lý null đúng cách
                return input.ToLower();
            return "OK";
        }

        private string connectionString = "Server=localhost;Database=TestDb;User Id=admin;Password=123456;"; // ❌ Hardcoded sensitive info

        [HttpGet("unused-variable")]
        public IActionResult UnusedVariable()
        {
            int unusedVariable = 42; // ❌ Unused variable
            return Ok("Check for unused variable.");
        }

        [HttpGet("exception-handling")]
        public IActionResult BadExceptionHandling()
        {
            try
            {
                int x = 1 / int.Parse("0"); // ❌ Divide by zero
            }
            catch (Exception) // ❌ Catching all exceptions silently
            {
            }
            return Ok("Check for bad exception handling.");
        }

        [HttpGet("string-compare")]
        public IActionResult StringComparisonIssue(string input)
        {
            if (input == "test") // ❌ Case-sensitive comparison
            {
                return Ok("Matched");
            }
            return Ok("Not matched");
        }

        [HttpGet("async-mistake")]
        public async Task<IActionResult> AsyncMistake()
        {
            SomeAsyncMethod(); // ❌ Missing await
            return Ok("Check for missing await");
        }

        private async Task SomeAsyncMethod()
        {
            await Task.Delay(1000);
        }

        [HttpGet("redundant-code")]
        public IActionResult RedundantCode()
        {
            // ❌ Repeated hardcoded logic
            Console.WriteLine("Freezing");
            Console.WriteLine("Bracing");
            Console.WriteLine("Chilly");
            Console.WriteLine("Cool");
            Console.WriteLine("Mild");
            Console.WriteLine("Warm");
            Console.WriteLine("Balmy");
            Console.WriteLine("Hot");
            Console.WriteLine("Sweltering");
            Console.WriteLine("Scorching");
            return Ok("Check for code repetition");
        }

        [HttpGet("null-check")]
        public IActionResult NullCheck()
        {
            string name = null;
            if (name.Length > 0) // ❌ Potential NullReferenceException
            {
                return Ok("Name is not empty");
            }
            return Ok("Check for null handling");
        }
    }
}
