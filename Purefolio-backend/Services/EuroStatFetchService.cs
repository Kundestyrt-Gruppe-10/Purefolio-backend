using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Purefolio_backend
{
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
                _logger.LogInformation("It worked");
            }else{
                _logger.LogInformation("It failed");
            }
        }

    }
}