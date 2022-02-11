using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MultipleDI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDI.Controllers
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
        private readonly IEnumerable<IService> _services;
        private readonly IServiceProvider serviceProvider;
        private readonly ServiceA serviceA;
        // type 1 ,2

        //public WeatherForecastController(ILogger<WeatherForecastController> logger, IEnumerable<IService> services, IServiceProvider serviceProvider)
        //{
        //    _logger = logger;
        //    _services = services; //1
        //    this.serviceProvider = serviceProvider;
        //    var B = serviceProvider.GetServices<IService>().First(o => o.GetType() == typeof(ServiceB));
        //}

        // type 3
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ServcieResolver serviceProvider , ServiceA service)
        {
            _logger = logger;
            var C = serviceProvider(ServiceType.C);
            serviceA = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
