using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetSonarLens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeAnalysisController : ControllerBase
    {
        [HttpGet("Test", Name = "GetTestData")]
        public string GetData(string? input)
        {
            if (input == null) // Bug tiềm ẩn: không xử lý null đúng cách
                return input.ToLower();
            return "OK";
        }

        [HttpGet("SQLInjection", Name = "GetQuerySQLInjection")]
        public string GetQuery(string userInput)
        {
            return 
                $"SELECT * FROM Users WHERE Name = '{userInput}'"; // SQL Injection
        }
    }
}
