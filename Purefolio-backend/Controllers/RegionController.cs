using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using System.Threading.Tasks;


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

        public async Task<ActionResult<IEnumerable<Region>>> GetAll()
        {
            return await databaseStore.getAllRegions();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> Get(int id)
        {
            Region region = await databaseStore.getRegionById(id);
            if (region == null) return NotFound();
            return Ok(region);
        }

        [HttpGet("hasdata/{naceId}/{tableId}")]
        public async Task<ActionResult<IEnumerable<RegionWithHasData>>> GetWithHasData(int naceId, int tableId)
        {
            return await databaseStore.getAllRegionsWithHasData(naceId: naceId, tableId: tableId);
        }
    }
}
