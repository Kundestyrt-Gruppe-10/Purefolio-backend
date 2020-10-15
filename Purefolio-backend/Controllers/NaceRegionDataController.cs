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

    private IDatabaseStore databaseStore;

    public NaceRegionDataController(
      ILogger<NaceRegionDataController> logger,
      DatabaseStore databaseStore
    )
    {
      _logger = logger;
      this.databaseStore = databaseStore;
    }

    [HttpGet("{regionId}/{naceId}/{year}")]
    public IEnumerable<NaceRegionData>
    Get(int? regionId, int? naceId, int? year)
    {
      return databaseStore
        .getNaceRegionData(regionId: regionId, naceId: naceId, year: year);
    }

    [HttpGet]
    public IEnumerable<NaceRegionData> Get()
    {
      return databaseStore.getNaceRegionData();
    }

    [HttpGet("{regionId}/{naceId}")]
    public IEnumerable<NaceRegionData> Get(int? regionId, int? naceId)
    {
      return databaseStore
        .getNaceRegionData(regionId: regionId, naceId: naceId);
    }
  }
}
