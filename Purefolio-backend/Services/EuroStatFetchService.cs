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

        public String GetEuroStatURL(EuroStatTable table)
        {
            return euroStatApiEndpoint + table.tableCode 
            + '?' + StaticFilters 
            + '&' + dsp.getNaceFilters() 
            + '&' + dsp.getTimeFilters()
            + '&' + table.unit;
        }

        public async Task<List<NaceRegionData>> PopulateDB()
        {
            List<EuroStatTable> tables = databaseStore.getAllEuroStatTables();
            int i = 0;
            int infoMaxLength = 70;
            string info;
            foreach (EuroStatTable table in tables)
            {
                // TODO: Handle no internet connection with proper error message.
                info = $"Saving data in database: {(double)i++ * 100 / tables.Count:0.0}% - {table.attributeName}";
                Console.Write($"\r{info}{Strings.Space(infoMaxLength - info.Length)}");

                HttpResponseMessage response = await client.GetAsync(GetEuroStatURL(table));
                String jsonString = response.Content.ReadAsStringAsync().Result;

                List<NaceRegionData> EurostatNRData = JSONConverter.convert(jsonString, table.attributeName);
                databaseStore.addNaceRegionData(EurostatNRData);
            }
            info = "Done saving data in database";
            Console.Write($"\r{info}{Strings.Space(infoMaxLength - info.Length)}");

            return databaseStore.getAllNaceRegionData();
        }
    }
}