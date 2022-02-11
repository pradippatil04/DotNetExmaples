using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPIWithCancellationToken.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    _logger.LogInformation("Called first method");
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet("WithCancellationToken")]
        public ActionResult<IEnumerable<string>> Get(CancellationToken cancellationToken)
        {
            List<string> lst = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                //cancellationToken.ThrowIfCancellationRequested(); //System.OperationCanceledException: 'The operation was canceled.'
                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Task Cancled");
                    break;
                }
                else
                {
                    var value = "value" + i;
                    lst.Add(value);
                    _logger.LogInformation(value);
                }
                Thread.Sleep(1000);
            }
            _logger.LogInformation("Task Finished");
            return lst;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> lst = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                var value = "value" + i;
                lst.Add(value);
                _logger.LogInformation(value);
                Thread.Sleep(1000);
            }
            _logger.LogInformation("Task Finished");
            return lst;
        }
    }
}
