using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using System.Linq;

namespace Purefolio_backend.Controllers
{
  [ApiController]
  [Route("/naceregiondata")]
  public class NaceRegionDataController : ControllerBase
  {
    private readonly ILogger<NaceRegionDataController> _logger;

    private IDatabaseStore databaseStore;

    public NaceRegionDataController(
      ILogger<NaceRegionDataController> logger,
      DatabaseStore databaseStore
    )
    {
      _logger = logger;
      this.databaseStore = databaseStore;
    }

    [HttpGet]
    [HttpGet("{regionId}/{naceId}")]
    [HttpGet("{regionId}/{naceId}/{year}")]
    public IEnumerable<NaceRegionData>
    Get(int? regionId, int? naceId, int? year, string? combaredBy)
    {
      List<NaceRegionData> data = databaseStore.getNaceRegionData(regionId: regionId, naceId: naceId, year: year);
      _logger.LogInformation(combaredBy);
      if (combaredBy != "area")
      {
        return data.Select(nrd => 
        {
          nrd.emissionPerYear = 10; 
          return nrd;
        }).ToList();
      }
      else
      {
        return  data;
      }
    }
  }
}
