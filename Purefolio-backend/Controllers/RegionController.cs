using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend.Controllers
{
  [ApiController]
  [Route("/regions")]
  public class RegionController : ControllerBase
  {
    private readonly ILogger<RegionController> _logger;

    public RegionController(ILogger<RegionController> logger)
    {
      _logger = logger;
    }

        private readonly ILogger<RegionController> _logger;

        private MockDataService mockDataService;

        public RegionController(ILogger<RegionController> logger, MockDataService mockDataService)
        {
            _logger = logger;
            this.mockDataService = mockDataService;
        }

        [HttpGet]
        public IEnumerable<Region> Get()
        {
            return mockDataService.getAllRegions();
        }
    }
  }
}
