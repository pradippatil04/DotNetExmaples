using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILogger<LoggingController> _logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
             _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            _logger.LogInformation($"geting information for id {id}");
            var list = new List<string> { "A", "C", "B" };

            _logger.LogInformation($"complted items are {string.Join(", ",list)}");
            return list;
        }

        public IActionResult GetByName(string name)
        {
            if(1== 0)
            {
              return  Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
