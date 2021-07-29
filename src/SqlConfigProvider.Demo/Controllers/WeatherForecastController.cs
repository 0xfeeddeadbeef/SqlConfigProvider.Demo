namespace SqlConfigProvider.Demo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _config;
        private readonly IOptions<MyOptions> _options;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IConfiguration config,
            IOptions<MyOptions> options)
        {
            _logger = logger;
            _config = config;
            _options = options;
        }


        [HttpGet]
        public string Get() =>
            $"Value directly from IConfiguration: MyValue = {_config["MyApp:MySettings:MyValue"]}\r\n" +
            $"Value from IOptions: MyValue = {_options.Value.MyValue}";

    }
}
