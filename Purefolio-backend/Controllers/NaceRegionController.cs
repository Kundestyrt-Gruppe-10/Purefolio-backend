using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend.Controllers
{
  [ApiController]
  [Route("/naceregiondata")]
  public class NaceRegionDataController : ControllerBase
  {
        private readonly ILogger<NaceRegionDataController> _logger;

        private MockDataStore mockDataStore;

        public NaceRegionDataController(ILogger<NaceRegionDataController> logger, MockDataStore mockDataStore)
        {
            _logger = logger;
            this.mockDataStore = mockDataStore;
        }

        [HttpGet]
        public IEnumerable<NaceRegionData> Get()
        {
            return mockDataStore.getAllNaceRegionData();
        }
      };
    }
