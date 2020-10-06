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
    public class EuroStatData
    {
        public string version {get; set;}
        public string label {get; set;}
        public string href {get; set;}
        public string source {get; set;}
        public string updated {get; set;}
        public object status {get; set;}
        public object extension {get; set;}
        public object value {get; set;}
        public object dimension {get; set;}
        public object id {get; set;}
        public object size {get; set;}
        
    }
    public class EuroStatFetchService

    {
        private readonly ILogger<EuroStatFetchService> _logger;
        static HttpClient client = new HttpClient();

        private DataSetProperties dsp = new DataSetProperties();

        private String euroStatApiEndpoint = "http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/";
        private static String StaticFilters = "precision=1";
        
        public EuroStatFetchService(ILogger<EuroStatFetchService> _logger, IHttpClientFactory clientFactory)

        {
            this._logger = _logger;
            this.clientFactory = clientFactory;
        }

        public String GetEuroStatURL(string tablecode)
        {
            return euroStatApiEndpoint + tablecode + '?' + StaticFilters + '&' + dsp.getFilters(tablecode);
        }

        public async void PopulateDB(string tablecode)
        {
            HttpResponseMessage response = await client.GetAsync(GetEuroStatURL(tablecode));
            String jsonString = response.Content.ReadAsStringAsync().Result;
            
            _logger.LogInformation(message:jsonString);
            
        }
    }
}