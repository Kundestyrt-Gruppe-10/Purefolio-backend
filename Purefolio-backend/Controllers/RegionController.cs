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

        public RegionController(ILogger<RegionController> logger, DatabaseStore databaseStore)
        {
            _logger = logger;
            this.databaseStore = databaseStore;
        }

        [HttpGet]
        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<Region>> Get(int? id)
        {
            if (id.HasValue)
            {
                Region region= databaseStore.getRegionById(id);
                if (region== null) return NotFound();
                return new List<Region>(){region};
            }
            return databaseStore.getAllRegions();
        }
    }
  }
