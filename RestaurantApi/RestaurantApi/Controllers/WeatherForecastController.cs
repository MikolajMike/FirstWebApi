using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantApi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastServices _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _service.Get();
            return result;
        }
        
        [HttpGet("currentDay/{max}")] // additional method
        //[Route("currentDay")] first method
        public IEnumerable<WeatherForecast> Get2([FromQuery]int take, [FromRoute]int max)
        {
            var result = _service.Get();
            return result;
        }
        
        [HttpPost]
        public ActionResult<string> Hello([FromBody] string name)
        {
            //HttpContext.Response.StatusCode = 401; // First method of set status code
            //return $"Hello {name}";
        
            //return StatusCode(401, $"Hello {name}"); // Second method of set status code
            return NotFound($"Hello {name}");// third method of set status code
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromBody]Temperature temperature, [FromQuery]int maxResult)
        {
            if (maxResult <= 0 || temperature.maxTemperature < temperature.minTemperature) return BadRequest();
            var result = _service.Get(temperature.minTemperature, temperature.maxTemperature, maxResult);
            return Ok(result);//10,15,20));
        }

    }
}
