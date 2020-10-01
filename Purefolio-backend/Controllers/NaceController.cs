using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend.Controllers
{
  [ApiController]
  [Route("/naces")]
  public class NaceController : ControllerBase
  {
        private readonly ILogger<NaceController> _logger;

        private MockData mockData;
        private readonly IDatabaseStore ds;

        public NaceController(
            ILogger<NaceController> logger, 
            MockData mockData,
            IDatabaseStore databaseStore
            )
        {
            _logger = logger;
            this.mockData = mockData;
            ds = databaseStore;
        }

        [HttpGet]
        public IEnumerable<Nace> GetAll()
        {
            return mockData.getAllNaces();
        }
        [HttpPost]
        public Nace CreateNace(Nace nace)
        {
            return ds.createNace(nace);
        }
    }
  }

