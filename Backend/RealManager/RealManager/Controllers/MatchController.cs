using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        public MatchController()
        {
            
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return null;
        }
    }
}
