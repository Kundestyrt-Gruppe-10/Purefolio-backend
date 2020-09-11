using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;

namespace Purefolio_backend.Controllers
{
    [ApiController]
    [Route("/nace")]
    public class NaceController : ControllerBase
    {

        private readonly ILogger<NaceController> _logger;

        public NaceController(ILogger<NaceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Nace> Get()
        {
            return new List<Nace>() {
                    new Nace() { NaceId = 1, NaceCode="Noe"} ,
                };
        }
    }
}