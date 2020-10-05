using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json; 

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

        private DataSetProperties dsp = new DataSetProperties();

        private String euroStatApiEndpoint = "http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/";
        private String staticFilters = "?precision=1&";

        private IHttpClientFactory clientFactory;
        
        public EuroStatFetchService(ILogger<EuroStatFetchService> _logger, IHttpClientFactory clientFactory)

        {
            this._logger = _logger;
            this.clientFactory = clientFactory;
        }

        public String getEuroStatURL(string tablecode)
        {
            string url = euroStatApiEndpoint + tablecode + staticFilters + dsp.getFilters(tablecode);
            _logger.LogInformation(message:url);
            return url;
        }

        public async void fetchData(string tablecode)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,getEuroStatURL(tablecode));

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<EuroStatData>(responseStream);
                _logger.LogInformation(data.value.ToString());
            }else{
                _logger.LogInformation("It failed");
            }
        }

    }
}