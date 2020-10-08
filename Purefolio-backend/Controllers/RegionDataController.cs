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

        private IDatabaseStore databaseStore;

        public RegionDataController(ILogger<RegionDataController> logger, IDatabaseStore databaseStore)
        {
            _logger = logger;
            this.databaseStore = databaseStore;
        }

        [HttpGet]
        public IEnumerable<RegionData> Get()
        {
            return databaseStore.getAllRegionData();
        }
      };
    }
