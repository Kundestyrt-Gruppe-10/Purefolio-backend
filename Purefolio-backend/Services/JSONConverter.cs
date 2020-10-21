using System;
using Purefolio_backend.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Reflection;

namespace Purefolio_backend
{
    public class JSONConverter
    {    
        private readonly ILogger<JsonConverter> _logger;
        private IDatabaseStore databaseStore;
        private JSONUnNester un;
        
        public JSONConverter(ILogger<JsonConverter> _logger, IDatabaseStore databaseStore)
        {
            this._logger = _logger;
            this.databaseStore = databaseStore;
        }
        
        public List<NaceRegionData> Convert(string jsonString, string attributeName)
        {
            un = new JSONUnNester(jsonString);
            List<NaceRegionData> nrdList = new List<NaceRegionData>();
            List<String> naceRegionYearFields = new List<String>();
            List<int> numberOfItemsInFields = new List<int>();
            
            
            if (!IsValidDataset(un.GetID(), un.GetSize()))
            {
                return nrdList;
            }

            (naceRegionYearFields, numberOfItemsInFields) = un.MakeOrderedLists();

            List<Region> regions = databaseStore.getAllRegions();
            List<Nace> naces = databaseStore.getAllNaces();

            
            foreach (KeyValuePair<String, String> entry in un.GetValues())
            {   
                List<int> indexes = findIndexesOfFields(int.Parse(entry.Key), numberOfItemsInFields);

                string naceCode = un.GetNaceCode(indexes, naceRegionYearFields);
                string regionCode = un.GetRegionCode(indexes, naceRegionYearFields);
                int year = un.GetYear(indexes, naceRegionYearFields);
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

        private Boolean IsValidDataset(List<String> id, List<int> size)
        {
            //checks for valid dataset (not more than 1 element in categories except for nace, geo, and time)
            // TODO: Actually handle when datasets are wrong.
            for (int i = 0; i < id.Count; i++)
            {   
                if (!(id.Contains("nace_r2") && id.Contains("geo") && id.Contains("time"))){
                    _logger.LogError(message:"Dataset invalid. It did not have all necessary fields.");
                    return false;
                }
                if (!(id[i].Equals("nace_r2") || id[i].Equals("geo") || id[i].Equals("time")) && !size[i].Equals(1))
                {
                    _logger.LogError(message:"Dataset invalid. " + id[i] + " did not have exactly 1 field.");
                    return false;
                }
            }
            return true;
        }

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