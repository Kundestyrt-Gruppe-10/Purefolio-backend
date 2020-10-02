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
    }
}