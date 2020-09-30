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

    public FetchController(
      ILogger<NaceController> logger,
      EuroStatFetchService euroStatFetchService
    )
    {
      _logger = logger;
      _euroStatFetchService = euroStatFetchService;
    }

        [HttpGet]
        [Route("output-url")]
        public void GetOutputUrl()
        {
            _euroStatFetchService.getEuroStatURL("env_wqdq");
        }

        [HttpGet]
        [Route("test")]
        public NaceRegionData getInfo()
        {
            NaceRegionData nrd =  new NaceRegionData(){ regionId=2, year=2019, genderPayGap = 1.3};
            NaceRegionData nrd2 =  new NaceRegionData(){ regionId=2, year=2019, emissionPerYer = 100};                 
            return nrd.merge(nrd2);
        }
    }
  }
