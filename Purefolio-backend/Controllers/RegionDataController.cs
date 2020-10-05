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

        private DatabaseStore ds;

        public RegionDataController(ILogger<RegionDataController> logger, DatabaseStore ds)
        {
            _logger = logger;
            this.ds = ds;
        }

        [HttpGet]
        public IEnumerable<RegionData> Get()
        {
            return ds.getAllRegionData();
        }
      };
    }
