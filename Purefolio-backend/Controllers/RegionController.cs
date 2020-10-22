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

        public ActionResult<List<Region>> GetAll()
        {
            return databaseStore.getAllRegions();
        }

        [HttpGet("{id}")]
        public ActionResult<Region> Get(int id)
        {
            Region region = databaseStore.getRegionById(id);
            if (region == null) return NotFound();
            return region;
        }
    }
  }
