using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using Purefolio.DatabaseContext;
using Purefolio_backend.Services;
using System;
using System.Threading.Tasks;

namespace Purefolio_backend.Controllers
{
    [ApiController]
    [Route("/populate")]
    public class PopulateDatabaseController : ControllerBase
    {
        private readonly ILogger<PopulateDatabaseController> _logger;
        private BaseDataService baseDataService;

        private EuroStatFetchService euroStatFetchService;


        public PopulateDatabaseController(
            ILogger<PopulateDatabaseController> logger,
            BaseDataService baseDataService, 
            EuroStatFetchService euroStatFetchService
            )
        {
            _logger = logger;
            this.baseDataService = baseDataService;
            this.euroStatFetchService = euroStatFetchService;
        }

        [HttpGet]
        public async Task<string> PopulateDatabaseWithBaseAndEurostatData()
        {
            baseDataService.PopulateDatabase();
            await euroStatFetchService.PopulateDB();
            return "Data is added";
        }

        [HttpGet]
        [Route("base")]
        public string PopulateDatabaseWithBaseData()
        {
            baseDataService.PopulateDatabase();
            return "Data is added";
        }

        [HttpGet]
        [Route("eurostat")]
        public async Task<string> PopulateDatabaseWithEurostatData()
        {
            await euroStatFetchService.PopulateDB();
            return "Data is added";
        }
    }
}