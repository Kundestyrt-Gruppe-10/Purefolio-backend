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

        private IDatabaseStore databaseStore;

        public RegionController(ILogger<RegionController> logger, IDatabaseStore databaseStore)
        {
            _logger = logger;
            this.databaseStore = databaseStore;
        }

        [HttpGet]
        public IEnumerable<Region> Get()
        {
            return databaseStore.getAllRegions();
        }
    }
  }
