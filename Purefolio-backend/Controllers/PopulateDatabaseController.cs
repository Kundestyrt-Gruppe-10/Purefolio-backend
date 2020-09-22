using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend.Controllers
{
    [ApiController]
    [Route("/populate")]
    public class PopulateDatabaseController : ControllerBase
    {

        private readonly ILogger<PopulateDatabaseController> _logger;

        public PopulateDatabaseController(ILogger<PopulateDatabaseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void PopulateDatabase()
        {

        }
    }
}