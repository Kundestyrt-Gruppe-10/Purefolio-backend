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

        private MockDataStore mockDataStore;

        public RegionController(ILogger<RegionController> logger, MockDataStore mockDataStore)
        {
            _logger = logger;
            this.mockDataStore = mockDataStore;
        }

        [HttpGet]
        public IEnumerable<Region> Get()
        {
            return mockDataStore.getAllRegions();
        }
    }
  }
