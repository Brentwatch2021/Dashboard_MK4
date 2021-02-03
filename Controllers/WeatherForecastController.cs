using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dashboard_MK4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "POESHOTS", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        //private readonly IEmailSender _emailSender;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)//IEmailSender emailSender)
        {
            //_emailSender = emailSender;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();


            //var message = new Message(new string[] { "beckerbrent04@gmail.com" }, "Test email", "This is the content from our email.");
            //_emailSender.SendEmail(message);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = "POESHOTS"
            })
            .ToArray();
        }
    }
}
