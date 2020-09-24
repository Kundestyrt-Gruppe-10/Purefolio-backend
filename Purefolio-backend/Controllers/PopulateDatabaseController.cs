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

        private MockDataStore mockDataStore;

        public PopulateDatabaseController(ILogger<PopulateDatabaseController> logger, DatabaseContext db, MockDataStore mockDataStore)
        {
            _logger = logger;
            this.db = db;
            this.mockDataStore = mockDataStore;
        }

        [HttpGet]
        public void PopulateDatabase()
        {
            foreach (Nace nace in mockDataStore.getAllNaces())
            {
                db.Nace.Add(nace);
            }

            foreach (RegionData regionData in mockDataStore.getAllRegionData())
            {
                db.RegionData.Add(regionData);
            }

            foreach (Region region in mockDataStore.getAllRegions())
            {
                db.Region.Add(region);
            }

            foreach (NaceRegionData naceRegionData in mockDataStore.getAllNaceRegionData())
            {
                db.NaceRegionData.Add(naceRegionData);
            }

            db.SaveChanges();
        }
    }
}