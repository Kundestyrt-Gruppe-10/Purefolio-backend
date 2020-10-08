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


        public PopulateDatabaseController(ILogger<PopulateDatabaseController> logger, MockData mockData,
            MockDataService mockDataService)
        {
            _logger = logger;
            this.mockDataService = mockDataService;
        }

        [HttpGet]
        public Boolean PopulateDatabase()
        {
            return mockDataService.PopulateDatabase();
        }
    }
}