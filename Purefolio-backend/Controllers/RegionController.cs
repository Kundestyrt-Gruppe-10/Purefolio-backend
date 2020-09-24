using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend.Controllers
{
  [ApiController]
  [Route("/regions")]
  public class RegionController : ControllerBase
  {
    private readonly ILogger<RegionController> _logger;

    public RegionController(ILogger<RegionController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Region> Get()
    {
      return new List<Region>()
      {
        new Region()
        { RegionId = 0, RegionCode = "NO", RegionName = "Norway", Area = 2 },
        new Region()
        { RegionId = 1, RegionCode = "SE", RegionName = "Sweden", Area = 2 },
        new Region()
        { RegionId = 2, RegionCode = "DK", RegionName = "Denmark", Area = 2 },
        new Region()
        { RegionId = 3, RegionCode = "FI", RegionName = "Finland", Area = 2 },
        new Region()
        {
          RegionId = 4,
          RegionCode = "EU",
          RegionName = "European Union",
          Area = 2
        }
      };
    }
  }
}
