using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using Purefolio.DatabaseContext;

namespace Purefolio_backend.Controllers
{
    [ApiController]
    [Route("/populate")]
    public class PopulateDatabaseController : ControllerBase
    {

        private readonly ILogger<PopulateDatabaseController> _logger;

        private DatabaseContext db;

        private MockDataService mockDataService;

        public PopulateDatabaseController(ILogger<PopulateDatabaseController> logger, DatabaseContext db, MockDataService mockDataService)
        {
            _logger = logger;
            this.db = db;
            this.mockDataService = mockDataService;
        }

        [HttpGet]
        public void PopulateDatabase()
        {
            foreach (Nace nace in mockDataService.getAllNaces())
            {
                db.Nace.Add(nace);
            }

            foreach (RegionData regionData in mockDataService.getAllRegionData())
            {
                db.RegionData.Add(regionData);
            }

            foreach (Region region in mockDataService.getAllRegions())
            {
                db.Region.Add(region);
            }

            foreach (NaceRegionData naceRegionData in mockDataService.getAllNaceRegionData())
            {
                db.NaceRegionData.Add(naceRegionData);
            }

            db.SaveChanges();
        }
    }
}