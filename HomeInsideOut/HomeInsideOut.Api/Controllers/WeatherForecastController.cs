using HomeInsideOut.Common.Api.Controllers;
using HomeInsideOut.Common.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HomeInsideOut.Api.Controllers
{
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<string> Get()
        {
            ResponseHelper.ReturnNotFound("Customer id not found");
            return Enumerable.Range(1, 5).Select(index => index.ToString()
            ).ToArray();
        }
    }
}