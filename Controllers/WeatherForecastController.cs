using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] summaries = new string[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", 
            "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

       [HttpGet(Name = "weatherforecast")]
       public WeatherForecast[] Weatherforecast () {

       var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
 
        return forecast; 
    }
    }
}