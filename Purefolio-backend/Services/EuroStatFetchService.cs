using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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

        public String GetEuroStatURL(string tableID, int index)
        {
            return euroStatApiEndpoint + dsp.getTableCode(tableID) + '?' + StaticFilters + '&' + dsp.getFilters(tableID, index);
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
                info = $"Saving data in database: {(double)i++ * 100 / tableIDs.Count:0.0}% - {tableID}";
                Console.Write($"\r{info}{Strings.Space(infoMaxLength - info.Length)}");

                await FetchAndStore(tableID);

            }
            info = "Done saving data in database";
            Console.Write($"\r{info}{Strings.Space(infoMaxLength - info.Length)}");

            return databaseStore.getAllNaceRegionData();
        }

        private async Task FetchAndStore(String tableID) 
        {
            int iteration = dsp.GetFetchIterationsLength();
            for (int i = 0; i < iteration; i++)
            {
            HttpResponseMessage response = await client.GetAsync(GetEuroStatURL(tableID, i));
            String jsonString = response.Content.ReadAsStringAsync().Result;

            List<NaceRegionData> EurostatNRData = JSONConverter.convert(jsonString, tableID);
            databaseStore.addNaceRegionData(EurostatNRData);
            }

        }
        /*
        List<filter> filterlist
        for filter in filters
        add filter to filterlist
        if(filterlist >= 50)


        */
    }
}