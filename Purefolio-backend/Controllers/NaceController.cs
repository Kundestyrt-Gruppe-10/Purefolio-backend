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

        private DatabaseStore ds;

        public NaceController(ILogger<NaceController> logger, DatabaseStore ds)
        {
            _logger = logger;
            this.ds = ds;
        }

        [HttpGet]
        public IEnumerable<Nace> Get()
        {
            return ds.getAllNaces();
        }
    }
  }

