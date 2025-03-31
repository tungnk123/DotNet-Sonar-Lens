using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetSonarLens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeAnalysisController : ControllerBase
    {
        [HttpGet("test", Name = "GetTestData")]
        public string GetData(string? input)
        {
            if (input == null) // Bug tiềm ẩn: không xử lý null đúng cách
                return input.ToLower();
            return "OK";
        }

    }
}
