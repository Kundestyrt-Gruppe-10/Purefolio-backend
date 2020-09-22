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

        private String euroStatApiEndpoint = "eurostat/jkalf/static";
        private List<String> naces = new List<string> {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U"};
        private List<int> years = new List<int> {2015,2016,2017,2018};
        public EuroStatFetchService(ILogger<EuroStatFetchService> _logger)

        {
            this._logger = _logger;
        }


        private String getNaceFilters()
        {
            return "nace_r2=" + string.Join("&nace_r2=", naces);
        }

        public String getEuroStatURL(string tablecode)
        {
            string url = euroStatApiEndpoint + tablecode + "?" + getNaceFilters();
            _logger.LogInformation(message:url);
            return url;
        }

        public void GetAirPolutionData()
        {
            String tableCode = "env_ac_ainah_r2";
            List<string> airPolData = new List<string> {"CO2"};

        }

    }
}