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
using Microsoft.VisualBasic;

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
        
        public EuroStatFetchService(ILogger<EuroStatFetchService> _logger, IHttpClientFactory clientFactory, DatabaseStore databaseStore, JSONConverter JSONConverter)

        {
            this._logger = _logger;
            this.databaseStore = databaseStore;
            this.JSONConverter = JSONConverter;
        }

        public String GetEuroStatURL(string tableID)
        {
            return euroStatApiEndpoint + dsp.getTableCode(tableID) + '?' + StaticFilters + '&' + dsp.getFilters(tableID);
        }

        public async Task<List<NaceRegionData>> PopulateDB()
        {   
            Dictionary<string, List<string>>.KeyCollection tableIDs = dsp.GetTableIDs();
            int i = 0;
            int infoMaxLength = 70;
            string info;
            foreach (var tableID in tableIDs)
            {
                // TODO: Handle no internet connection with proper error message.
            info = $"Saving data in database: {(double) i++*100/tableIDs.Count:0.0}% - {tableID}";
            Console.Write($"\r{info}{Strings.Space(infoMaxLength-info.Length)}");

            HttpResponseMessage response = await client.GetAsync(GetEuroStatURL(tableID));
            String jsonString = response.Content.ReadAsStringAsync().Result;
            
            List<NaceRegionData> EurostatNRData = JSONConverter.convert(jsonString, tableID);
            databaseStore.addNaceRegionData(EurostatNRData);
            }
            info = "Done saving data in database";
            Console.Write($"\r{info}{Strings.Space(infoMaxLength-info.Length)}");
            
            return databaseStore.getAllNaceRegionData();
        }
    }
}