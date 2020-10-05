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

        private DatabaseStore ds;

        public NaceRegionDataController(ILogger<NaceRegionDataController> logger, DatabaseStore ds)
        {
            _logger = logger;
            this.ds = ds;
        }

        [HttpGet]
        public IEnumerable<NaceRegionData> Get()
        {
            return ds.getAllNaceRegionData();
        }
      };
    }
