using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Purefolio_backend.Controllers
{
  [ApiController]
  [Route("/tables")]
  public class EuroStatTableController : ControllerBase
  {
    private readonly ILogger<EuroStatTableController> _logger;

    private IDatabaseStore _databaseStore;

    public EuroStatTableController(
      ILogger<EuroStatTableController> logger, IDatabaseStore databaseStore
    )
    {
      _logger = logger;
      _databaseStore = databaseStore;
    }

    [HttpGet]
    public async Task<List<EuroStatTable>> getAllTables()
    {
        return await _databaseStore.getAllEuroStatTables();
    }
    //TODO: Remove this when frontend uses getAllTables-endpoint
    [HttpGet]
    [Route("esg-factors")]
    public async Task<List<string>> getESGFactors()
    {
        List<EuroStatTable> allEurostatTables = await _databaseStore.getAllEuroStatTables();
        return allEurostatTables.ConvertAll((EuroStatTable table) => table.attributeName);
    }
  }
}
