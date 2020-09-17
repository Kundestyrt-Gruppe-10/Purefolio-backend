using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend.Controllers
{
    [ApiController]
    [Route("/regiondata")]
    public class RegionDataController : ControllerBase
    {

        private readonly ILogger<RegionDataController> _logger;

        public RegionDataController(ILogger<RegionDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<RegionData> Get()
        {
            return new List<RegionData>() 
            { 
                new RegionData() { RegionDataId = 0, RegionId = 0, corruptionRate = 84, year = 2019, population = 5328212, gdp = 360300 },
                new RegionData() { RegionDataId = 1, RegionId = 1, corruptionRate = 85, year = 2019, population = 10230185, gdp = 474194},
                new RegionData() { RegionDataId = 2, RegionId = 2, corruptionRate = 87, year = 2019, population = 5806081, gdp = 310002},
                new RegionData() { RegionDataId = 3, RegionId = 3, corruptionRate = 86, year = 2019, population = 5517919, gdp = 240557},
                new RegionData() { RegionDataId = 4, RegionId = 4, corruptionRate = 0, year = 2019, population = 446824564, gdp = 13953148},
                

            };
        }
    }
}