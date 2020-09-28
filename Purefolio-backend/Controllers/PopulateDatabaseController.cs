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

        private MockData mockData;

        public PopulateDatabaseController(ILogger<PopulateDatabaseController> logger, DatabaseContext db, MockData mockData)
        {
            _logger = logger;
            this.db = db;
            this.mockData = mockData;
        }

        [HttpGet]
        public void PopulateDatabase()
        {
            foreach (Nace nace in mockData.getAllNaces())
            {
                db.Nace.Add(nace);
            }

            foreach (RegionData regionData in mockData.getAllRegionData())
            {
                db.RegionData.Add(regionData);
            }

            foreach (Region region in mockData.getAllRegions())
            {
                db.Region.Add(region);
            }

            foreach (NaceRegionData naceRegionData in mockData.getAllNaceRegionData())
            {
                db.NaceRegionData.Add(naceRegionData);
            }

            db.SaveChanges();
        }
    }
}