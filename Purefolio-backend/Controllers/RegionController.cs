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

        private DatabaseStore ds;

        public RegionController(ILogger<RegionController> logger, DatabaseStore ds)
        {
            _logger = logger;
            this.ds = ds;
        }

        [HttpGet]
        public IEnumerable<Region> Get()
        {
            return ds.getAllRegions();
        }
    }
  }
