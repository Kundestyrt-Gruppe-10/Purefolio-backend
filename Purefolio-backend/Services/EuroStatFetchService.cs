using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purefolio_backend
{
    public class EuroStatFetchService

    {
        private readonly ILogger<EuroStatFetchService> _logger;
        public EuroStatFetchService(ILogger<EuroStatFetchService> _logger)

        {
            this._logger = _logger;
        }

        public IEnumerable<Nace> GetAllNaces()
        {
            return new List<Nace>() {

                new Nace() { NaceId = 0, NaceCode = "A", NaceName = "Agriculture, forestry and fishing" },

                new Nace() { NaceId = 1, NaceCode = "B", NaceName = "Mining and quarrying" },

                new Nace() { NaceId = 2, NaceCode = "C", NaceName = "Manufacturing" }
            };

        }

    }
}