using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using System.Threading.Tasks;


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
        public async Task<IEnumerable<RegionData>> GetAllRegionData()
        {
            return await databaseStore.getAllRegionData();
        }
      };
    }
