using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using System.Linq;
using System.Threading.Tasks;


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
      IDatabaseStore databaseStore
    )
    {
      _logger = logger;
      this.databaseStore = databaseStore;
    }

    [HttpGet]
    [HttpGet("{regionId}/{naceId}")]
    public async Task<IEnumerable<NaceRegionData>>
    Get(int? regionId, int? naceId, [FromQuery] int? fromYear= null, [FromQuery] int? toYear= null)
    {
      return await databaseStore.getNaceRegionData(regionId: regionId, naceId: naceId, fromYear:fromYear, toYear:toYear);
    }

    [HttpGet("years")]
    public async Task<IEnumerable<int>>
    GetYearsWithData()
    {
      return  await databaseStore.getYearsWithData();
    }
  }
}
