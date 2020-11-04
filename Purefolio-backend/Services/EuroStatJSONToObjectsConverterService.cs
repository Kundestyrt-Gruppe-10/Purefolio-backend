using System;
using Purefolio_backend.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Reflection;
using Purefolio_backend.Utils;
using System.Threading.Tasks;


namespace Purefolio_backend.Services
{
    public class EuroStatJSONToObjectsConverterService
    {    
        private readonly ILogger<JsonConverter> _logger;
        private IDatabaseStore databaseStore;
        private EuroStatJSONUnNester un;
        
        public EuroStatJSONToObjectsConverterService(ILogger<JsonConverter> _logger, IDatabaseStore databaseStore)
        {
            this._logger = _logger;
            this.databaseStore = databaseStore;
        }
        
        /// <summary>
        /// Converts a JSON-file on string format to a list of corresponding NaceRegionData objects.
        /// </summary>
        /// <param name="jsonString">A JSON object represented as a string</param>
        /// <param name="attributeName">The name of the datafield. Used to find and set the correct property in NaceRegionObjects</param>
        /// <returns></returns>
        public async Task<List<NaceRegionData>> Convert(string jsonString, string attributeName)
        {
            un = new EuroStatJSONUnNester(jsonString);
            List<NaceRegionData> nrdList = new List<NaceRegionData>();
            List<String> naceRegionYearFields = new List<String>();
            List<int> numberOfItemsInFields = new List<int>();
            
            
            if (!un.IsValidDataset())
            {
                return nrdList;
            }

            List<Region> regions = await databaseStore.getAllRegions();
            List<Nace> naces = await databaseStore.getAllNaces();

            
            foreach (KeyValuePair<String, String> entry in un.GetValues())
            {   
                List<int> totalElementsList = un.GetFields().ConvertAll(field => field.totalElements);
                List<int> indexes = findIndexesOfFields(int.Parse(entry.Key), totalElementsList);

                int naceId = indexes[un.GetFieldIndex("nace")];
                int regionId = indexes[un.GetFieldIndex("region")];
                int yearId = indexes[un.GetFieldIndex("year")];

                string naceCode = un.GetNaceCode(naceId:naceId);
                string regionCode = un.GetRegionCode(regionId:regionId);
                int year = un.GetYear(yearId:yearId);

                double propValue = double.Parse(entry.Value, CultureInfo.InvariantCulture);

                Nace nace = naces.Find(nace => nace.naceCode == naceCode);
                Region region = regions.Find(region => region.regionCode == regionCode);

                if (nace != null && region != null)
                {
                    NaceRegionData nrd = new NaceRegionData(){naceId=nace.naceId, regionId=region.regionId, year=year};
                    Type type = nrd.GetType();
                    PropertyInfo prop = type.GetProperty(attributeName);
                    prop.SetValue (nrd, propValue, null);
                    nrdList.Add(nrd);
                }
             }
            return nrdList;
        }


        /// <summary>
        ///  Computes and returns a list of indexes of nace_r2, geo, and time in the order they appear in the JSON-file.
        /// </summary>
        /// <param name="indexOfData">Integer index of a single value in the Eurostat JSON file</param>
        /// <param name="numberOfItemsInFields">list of how many elements is in each of nace_r2, geo, and time, in the order they appear in the JSON-file</param>
        /// <returns></returns>
        public List<int> findIndexesOfFields(int indexOfData, List<int> numberOfItemsInFields)
        {
            List<int> indexes = new List<int>();

            //modulus operations to find the indexes of nace, region, and year in any order
            indexes.Add(indexOfData / (numberOfItemsInFields[1]*numberOfItemsInFields[2]));
            indexes.Add((indexOfData % (numberOfItemsInFields[1]*numberOfItemsInFields[2]) / numberOfItemsInFields[2]));
            indexes.Add((indexOfData % (numberOfItemsInFields[1]*numberOfItemsInFields[2])) % numberOfItemsInFields[2]);
            return indexes;
        }
    }
}