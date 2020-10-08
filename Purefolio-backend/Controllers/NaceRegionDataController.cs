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

        private DatabaseStore databaseStore;

        public NaceRegionDataController(ILogger<NaceRegionDataController> logger, DatabaseStore databaseStore)
        {
            _logger = logger;
            this.databaseStore = databaseStore;
        }

        [HttpGet]
        public IEnumerable<NaceRegionData> Get(int? regionId, int? naceId, int? year)
        {
            return databaseStore.getNaceRegionData(regionId:regionId, naceId:naceId, year:year);
        }
      };
    }
