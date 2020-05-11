namespace Kalbe.Calculator.WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;

    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IConfiguration _config;

        public CalculatorController(ILogger<CalculatorController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        [HttpGet]
        public IActionResult Multiplication()
        {
            ViewData["EnvironmentName"] = _config.GetSection("Environment").Value;
            return View();
        }

        [HttpGet]
        public IActionResult Division()
        {
            ViewData["EnvironmentName"] = _config.GetSection("Environment").Value;
            return View();
        }


        [HttpGet]
        public IActionResult Addition()
        {
            ViewData["EnvironmentName"] = _config.GetSection("Environment").Value;
            return View();
        }


        [HttpGet]
        public IActionResult Substraction()
        {
            ViewData["EnvironmentName"] = _config.GetSection("Environment").Value;
            return View();
        }

        [HttpPost]
        public JsonResult Calculate(string mode, decimal val1, decimal val2)
        {
            string message = "";
            decimal result = 0;

            switch (mode.ToUpperInvariant())
            {
                case "X":
                    result = val1 * val2;
                    break;
                case ":":
                    result = val1 / val2;
                    break;
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                default:
                    message = "No operation method for " + mode;
                    break;
            }

            return Json(new { message, result });
        }
    }
}