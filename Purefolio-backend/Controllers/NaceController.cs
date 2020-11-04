using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using System.Threading.Tasks;


namespace Purefolio_backend.Controllers
{
  [ApiController]
  [Route("/naces")]
  public class NaceController : ControllerBase
  {
      private readonly ILogger<NaceController> _logger;

      private IDatabaseStore databaseStore;

      public NaceController(ILogger<NaceController> logger, IDatabaseStore databaseStore)
        {
            _logger = logger;
            this.databaseStore = databaseStore;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nace>>> GetAll()
        {
            return await databaseStore.getAllNaces();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Nace>> GetSingle(int id)
        {
            Nace nace = await databaseStore.getNaceById(id);
            if (nace == null) return NotFound();
            return Ok(nace);
        }

        [HttpGet("hasdata/{regionId}/{tableId}")]
        public async Task<ActionResult<IEnumerable<NaceWithHasData>>> Get(int regionId, int tableId)
        {
            return await databaseStore.getAllNacesWithHasData(regionId:regionId, tableId:tableId);
        }
    }
  }

