using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Purefolio_backend
{
    public class EuroStatFetchService
    {
        private readonly ILogger<EuroStatFetchService> _logger;
        static HttpClient client = new HttpClient();
        private JSONConverter JSONConverter;
        private DatabaseStore databaseStore;  

        private static string euroStatApiEndpoint = "http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/";
        private static string StaticFilters = "precision=1";
        private static int MaxElementsFromFetch = 50;
        private static int StartYear = 2015;
        private static int EndYear = 2018;

        public EuroStatFetchService(ILogger<EuroStatFetchService> _logger, IHttpClientFactory clientFactory, DatabaseStore databaseStore, JSONConverter JSONConverter)
        {
            this._logger = _logger;
            this.databaseStore = databaseStore;
            this.JSONConverter = JSONConverter;
        }

        public async Task<List<NaceRegionData>> PopulateDB()
        {
            List<EuroStatTable> tables = databaseStore.getAllEuroStatTables();
            int i = 0;
            int infoMaxLength = 70;
            string info;
            foreach (EuroStatTable table in tables)
            {
                info = $"Saving data in database: {(double)i++ * 100 / tables.Count:0.0}% - {table.attributeName}";
                Console.Write($"\r{info}{Strings.Space(infoMaxLength - info.Length)}");
                await FetchAndStore(table);
            }
            info = "Done saving data in database";
            Console.WriteLine($"\r{info}{Strings.Space(infoMaxLength - info.Length)}");
            return databaseStore.getAllNaceRegionData();
        }
        // TODO: Change no internet connection handling
        private async Task FetchAndStore(EuroStatTable table) 
        {
            List<Nace> naces = databaseStore.getAllNaces();
            int iterationCount = GetFetchIterationsCount(naces);
            for (int i = 0; i < iterationCount; i++)
            {
                string url = GetEuroStatURL(table, i, naces);
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    //Console.WriteLine("URL: " + url);
                    if (response.IsSuccessStatusCode) 
                    {
                        string jsonString = response.Content.ReadAsStringAsync().Result;
                        List<NaceRegionData> EurostatNRData = JSONConverter.convert(jsonString, table.attributeName);
                        databaseStore.addNaceRegionData(EurostatNRData);
                    }  
                    else 
                    {
                        await handleStatusCodeNotSuccess((int)response.StatusCode, response, table, i, url, naces);
                    }
                }
                catch (System.Net.Http.HttpRequestException e)
                {
                    _logger.LogWarning("No internet connection, check your network configuration and try again" + "\nError trace: " + e);
                    throw new Exception();
                }

            
            }  
        }

        public String GetEuroStatURL(EuroStatTable table, int index, List<Nace> naces)
        {
            return euroStatApiEndpoint + table.tableCode 
            + '?' + StaticFilters 
            + '&' + GetNaceFilters(index, naces)
            + '&' + GetTimeFilters(StartYear, EndYear)
            + '&' + table.unit;
        }

        private String GetNaceFilters(int index, List<Nace> naces)
        {
            int start = index * MaxElementsFromFetch;
            int count = MaxElementsFromFetch;
            if (naces.Count < count * (index + 1)) 
            {
                count = naces.Count - (index * MaxElementsFromFetch);
            }
            List<Nace> queryNaces = naces.GetRange(start, count);
            string naceFilters = "nace_r2=";
            for (int i = 0; i < queryNaces.Count - 1; i++)
            {
                naceFilters += queryNaces[i].naceCode + "&nace_r2=";
            }
            naceFilters += queryNaces[queryNaces.Count - 1].naceCode; 
            return naceFilters;
        }

        private int GetFetchIterationsCount(List<Nace> naces) 
        {
            int iterations = (int)Math.Ceiling((decimal)naces.Count / (decimal)MaxElementsFromFetch);
            return iterations;
        }

        public String GetTimeFilters(int startYear, int endYear){
            List<int> years = new List<int>();
            for (int i = startYear; i <= endYear; i++)
            {
                years.Add(i);
            }
            return "time=" + string.Join("&time=", years);
        }

        private String GetErrorMessage(HttpResponseMessage response){
            return (String)(JsonConvert.DeserializeObject<Dictionary<String, Object>>
                ((JsonConvert.DeserializeObject<Dictionary<String, Object>>
                (response.Content.ReadAsStringAsync().Result))["error"].ToString()))["label"];
        }

        private async Task handleStatusCodeNotSuccess(int statusCode, HttpResponseMessage response, EuroStatTable table, int i, string url, List<Nace> naces){
            int timeoutCounter = 0;
            while (statusCode == 503 && timeoutCounter < 10) 
            {
                response = await client.GetAsync(url);
                System.Threading.Thread.Sleep(100);
                timeoutCounter++;
                if (timeoutCounter >= 10) 
                {
                    _logger.LogWarning("Warning: Service unavailable for fetching data from eurostat on URL: " + GetEuroStatURL(table, i, naces));
                }
            }
            if (GetErrorMessage(response).Equals("Dataset contains no data. One or more filtering elements (query parameters) are probably invalid."))
            {
                _logger.LogInformation(message:"Dataset contains no data. Nothing from the fetch to: " + url + " was stored.");
            }
            else if (statusCode >= 400 && !(statusCode == 503 && timeoutCounter >= 10)) 
            {    
                _logger.LogWarning("For dataset: " + table.attributeName + ". ERROR: " + GetErrorMessage(response));
            }
        }
    }
}