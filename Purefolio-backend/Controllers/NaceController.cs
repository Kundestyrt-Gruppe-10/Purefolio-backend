using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<Nace>> GetAll()
        {
            return databaseStore.getAllNaces();
        }

        [HttpGet("{id}")]
        public ActionResult<Nace> GetSingle(int id)
        {
            Nace nace = databaseStore.getNaceById(id);
            if (nace == null) return NotFound();
            return Ok(nace);
        }

        [HttpGet("hasdata/{regionId}/{tableId}")]
        public ActionResult<IEnumerable<NaceWithHasData>> Get(int regionId, int tableId)
        {
            return databaseStore.getAllNacesWithHasData(regionId:regionId, tableId:tableId);
        }
    }
  }

