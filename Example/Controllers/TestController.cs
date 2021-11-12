using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example.Controllers
{
    public class TestController : Controller
    {
        /// <summary>
        /// 日誌
        /// </summary>
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }
                
        public IActionResult Index()
        {
            _logger.LogError("測試封裝日誌");
            int i = 0;
            int result = 10 / i;
            return Ok();
        }
    }
}
