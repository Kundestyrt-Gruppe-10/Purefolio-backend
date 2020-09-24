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

        private MockDataService mockDataService;

        public NaceController(ILogger<NaceController> logger, MockDataService mockDataService)
        {
            _logger = logger;
            this.mockDataService = mockDataService;
        }

        [HttpGet]
        public IEnumerable<Nace> Get()
        {
            return mockDataService.getAllNaces();
        }
    }
  }

