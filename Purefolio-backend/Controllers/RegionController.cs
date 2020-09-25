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

        private MockData mockData;

        public RegionController(ILogger<RegionController> logger, MockData mockData)
        {
            _logger = logger;
            this.mockData = mockData;
        }

        [HttpGet]
        public IEnumerable<Region> Get()
        {
            return mockData.getAllRegions();
        }
    }
  }
