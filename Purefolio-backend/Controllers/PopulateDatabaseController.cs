using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using Purefolio.DatabaseContext;
using Purefolio_backend.Services;
using System;

namespace Purefolio_backend.Controllers
{
    [ApiController]
    [Route("/populate")]
    public class PopulateDatabaseController : ControllerBase
    {

        private readonly ILogger<PopulateDatabaseController> _logger;


        private MockDataService mockDataService;

        private DatabaseStore databaseStore;

        public PopulateDatabaseController(ILogger<PopulateDatabaseController> logger, DatabaseStore databaseStore, MockData mockData,
            MockDataService mockDataService)
        {
            _logger = logger;
            this.mockDataService = mockDataService;
            this.databaseStore = databaseStore;
        }

        [HttpGet]
        public Boolean PopulateDatabase()
        {
            return mockDataService.PopulateDatabase();
        }

        [HttpGet]
        [Route("merge-rd")]
        public List<RegionData> AddRegionData()
        {
            List<RegionData> newData = new List<RegionData>(){
                new RegionData() { regionId = 1, year = 2018, population = 482353484},
                new RegionData() { regionId = 2, year = 2018, population = 482353634},
                new RegionData() { regionId = 3, year = 2018, population = 482348634},
                new RegionData() { regionId = 4,  year = 2018, population = 435348634},
                new RegionData() { regionId = 5,  year = 2018, population = 235348634},
            };

            return databaseStore.addRegionData(newData);
        }

        [HttpGet]
        [Route("merge-nrd")]
        public List<NaceRegionData> AddNaceRegionData()
        {
            List<NaceRegionData> newData = new List<NaceRegionData>(){
                new NaceRegionData() { regionId = 1, naceId = 15,  year = 2018, emissionPerYer = 4567078 },   
                new NaceRegionData() { regionId = 2, naceId = 15, year = 2018, emissionPerYer = 435365 },  
            };

            return databaseStore.addNaceRegionData(newData);
        }

    }
}