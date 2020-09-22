using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend.Controllers
{
    [ApiController]
    [Route("/fetch")]
    public class FetchController : ControllerBase
    {

        private readonly ILogger<NaceController> _logger;
        private EuroStatFetchService _euroStatFetchService;

        public FetchController(ILogger<NaceController> logger, EuroStatFetchService euroStatFetchService)
        {
            _logger = logger;
            _euroStatFetchService = euroStatFetchService;
        }

        [HttpGet]
        [Route("naces")]
        public IEnumerable<Nace> GetAllNaces()
        {
            return _euroStatFetchService.GetAllNaces();
        }
    }
}