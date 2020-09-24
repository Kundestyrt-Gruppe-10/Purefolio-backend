using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend.Controllers
{
  [ApiController]
  [Route("/naceregiondata")]
  public class NaceRegionDataController : ControllerBase
  {
    private readonly ILogger<NaceRegionDataController> _logger;

    public NaceRegionDataController(ILogger<NaceRegionDataController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<NaceRegionData> Get()
    {
      return new List<NaceRegionData>()
      {
        new NaceRegionData()
        {
          RegionId = 0,
          year = 2018,
          NaceId = 0,
          emissionPerYer = -1,
          genderPayGap = 14
        },
        new NaceRegionData()
        {
          RegionId = 0,
          year = 2018,
          NaceId = 1,
          emissionPerYer = -1,
          genderPayGap = 6.4
        }
      };
    }
  }
}
