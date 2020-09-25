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

        private MockData mockData;

        public NaceRegionDataController(ILogger<NaceRegionDataController> logger, MockData mockData)
        {
            _logger = logger;
            this.mockData = mockData;
        }

        [HttpGet]
        public IEnumerable<NaceRegionData> Get()
        {
            return mockData.getAllNaceRegionData();
        }
      };
    }
