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

        private MockDataService mockDataService;

        public RegionDataController(ILogger<RegionDataController> logger, MockDataService mockDataService)
        {
            _logger = logger;
            this.mockDataService = mockDataService;
        }

        [HttpGet]
        public IEnumerable<RegionData> Get()
        {
            return mockDataService.getAllRegionData();
        }
      };
    }
