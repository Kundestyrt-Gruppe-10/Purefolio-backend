using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Purefolio_backend
{
    public class EuroStatFetchService

    {
        private readonly ILogger<EuroStatFetchService> _logger;
        static HttpClient client = new HttpClient();

        private DataSetProperties dsp = new DataSetProperties();
        private JSONConverter JSONConverter;

        private String euroStatApiEndpoint = "http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/";
        private static String StaticFilters = "precision=1";

        private DatabaseStore databaseStore;
        
        public EuroStatFetchService(ILogger<EuroStatFetchService> _logger, IHttpClientFactory clientFactory, DatabaseStore databaseStore, JSONConverter jSONConverter)

        {
            this._logger = _logger;
            this.databaseStore = databaseStore;
            this.JSONConverter = jSONConverter;
        }

        public String GetEuroStatURL(string tablecode)
        {
            return euroStatApiEndpoint + tablecode + '?' + StaticFilters + '&' + dsp.getFilters(tablecode);
        }

        public async Task<List<NaceRegionData>> PopulateDB(string tablecode)
        {
            // TODO: Handle no internet connection with proper error message.
            HttpResponseMessage response = await client.GetAsync(GetEuroStatURL(tablecode));
            String jsonString = response.Content.ReadAsStringAsync().Result;
            
            List<NaceRegionData> EurostatNRData = JSONConverter.convert(jsonString, tablecode);
            databaseStore.addNaceRegionData(EurostatNRData);
            
            return EurostatNRData;
        }
    }
}