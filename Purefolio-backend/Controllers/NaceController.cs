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

        private MockDataStore mockDataStore;

        public NaceController(ILogger<NaceController> logger, MockDataStore mockDataStore)
        {
            _logger = logger;
            this.mockDataStore = mockDataStore;
        }

        [HttpGet]
        public IEnumerable<Nace> Get()
        {
            return mockDataStore.getAllNaces();
        }
    }
  }

