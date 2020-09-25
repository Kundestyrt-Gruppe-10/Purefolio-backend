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

        private MockData mockData;

        public NaceController(ILogger<NaceController> logger, MockData mockData)
        {
            _logger = logger;
            this.mockData = mockData;
        }

        [HttpGet]
        public IEnumerable<Nace> Get()
        {
            return mockData.getAllNaces();
        }
    }
  }

