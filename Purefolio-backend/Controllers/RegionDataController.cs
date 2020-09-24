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

        private MockDataStore mockDataStore;

        public RegionDataController(ILogger<RegionDataController> logger, MockDataStore mockDataStore)
        {
            _logger = logger;
            this.mockDataStore = mockDataStore;
        }

        [HttpGet]
        public IEnumerable<RegionData> Get()
        {
            return mockDataStore.getAllRegionData();
        }
      };
    }
