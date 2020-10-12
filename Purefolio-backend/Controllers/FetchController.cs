using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Purefolio_backend.Controllers
{
  [ApiController]
  [Route("/fetch")]
  public class FetchController : ControllerBase
  {
    private readonly ILogger<NaceController> _logger;

    private EuroStatFetchService _euroStatFetchService;

    public FetchController(
      ILogger<NaceController> logger,
      EuroStatFetchService euroStatFetchService
    )
    {
      _logger = logger;
      _euroStatFetchService = euroStatFetchService;
    }

       /* [HttpGet]
        [Route("output-url")]
        public void GetOutputUrl()
        {
            _euroStatFetchService.GetEuroStatURL("env_ac_taxind2");
        }*/

        [HttpGet]
        [Route("populate-db")]
        public async Task<List<NaceRegionData>> PopulateDB()
        {
            return await _euroStatFetchService.PopulateDB();
        }
    }
  }
