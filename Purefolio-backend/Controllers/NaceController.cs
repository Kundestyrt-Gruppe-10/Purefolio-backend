using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend.Controllers
{
  [ApiController]
  [Route("/naces")]
  public class NaceController : ControllerBase
  {
      private readonly ILogger<NaceController> _logger;

      private IDatabaseStore databaseStore;

      public NaceController(ILogger<NaceController> logger, DatabaseStore databaseStore)
        {
            _logger = logger;
            this.databaseStore = databaseStore;
        }

        [HttpGet]
        public IEnumerable<Nace> Get()
        {
          return databaseStore.getAllNaces();
        }
    }
  }

