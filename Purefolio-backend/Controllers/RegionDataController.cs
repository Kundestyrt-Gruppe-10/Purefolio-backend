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

        private MockData mockData;

        public RegionDataController(ILogger<RegionDataController> logger, MockData mockData)
        {
            _logger = logger;
            this.mockData = mockData;
        }

        [HttpGet]
        public IEnumerable<RegionData> Get()
        {
            return mockData.getAllRegionData();
        }
      };
    }
