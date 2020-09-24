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

        private MockDataService mockDataService;

        public NaceRegionDataController(ILogger<NaceRegionDataController> logger, MockDataService mockDataService)
        {
            _logger = logger;
            this.mockDataService = mockDataService;
        }

        [HttpGet]
        public IEnumerable<NaceRegionData> Get()
        {
            return mockDataService.getAllNaceRegionData();
        }
      };
    }
