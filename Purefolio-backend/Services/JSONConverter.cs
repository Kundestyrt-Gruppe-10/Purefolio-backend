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
        private DatabaseStore databaseStore;
        
        public JSONConverter(ILogger<JsonConverter> _logger, DatabaseStore databaseStore)
        {
            this._logger = _logger;
            this.databaseStore = databaseStore;
        }
        
        public List<NaceRegionData> Convert(string jsonString, string attributeName)
        {
            List<NaceRegionData> nrdList = new List<NaceRegionData>();
            List<String> naceRegionYearFields = new List<String>();
            List<int> numberOfItemsInFields = new List<int>();
            
            // Deserialize the nested JSON file
            var jsonDict = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonString);
            var value = JsonConvert.DeserializeObject<Dictionary<String, String>>(jsonDict["value"].ToString());
            var id = JsonConvert.DeserializeObject<List<String>>(jsonDict["id"].ToString());
            var size = JsonConvert.DeserializeObject<List<int>>(jsonDict["size"].ToString());
            
            if (!IsValidDataset(id, size))
            {
                return nrdList;
            }

            (naceRegionYearFields, numberOfItemsInFields) = MakeOrderedLists(id, size);

            List<Region> regions = databaseStore.getAllRegions();
            List<Nace> naces = databaseStore.getAllNaces();

            
            foreach (KeyValuePair<String, String> entry in value)
            {   
                List<int> indexes = findIndexesOfFields(int.Parse(entry.Key), numberOfItemsInFields);

                string naceCode = GetNaceCode(jsonDict, indexes, naceRegionYearFields);
                string regionCode = GetRegionCode(jsonDict, indexes, naceRegionYearFields);
                int year = GetYear(jsonDict, indexes, naceRegionYearFields);
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
                if (!(id[i].Equals("nace_r2") || id[i].Equals("geo") || id[i].Equals("time")) && !size[i].Equals(1))
                {
                        _logger.LogError(message:"Dataset invalid. " + id[i] + " did not have exactly 1 field.");
                        return false;
                }
            }
            return true;
        }

        private (List<String>, List<int>) MakeOrderedLists(List<String> id, List<int> size)
        {
            List<String> naceRegionYearFields = new List<String>();
            List<int> numberOfItemsInFields = new List<int>();

            for (int i = 0; i < id.Count; i++)
            {   
                if(id[i].Equals("nace_r2") || id[i].Equals("geo") || id[i].Equals("time"))
                {
                    naceRegionYearFields.Add(id[i]);
                    numberOfItemsInFields.Add(size[i]);
                }
            }
            return (naceRegionYearFields, numberOfItemsInFields);
        }

        private Dictionary<int, String> GetNestedField(string field_name, Dictionary<String, Object> jsonDict)
        {
            return JsonConvert.DeserializeObject<Dictionary<String, int>>
            ((JsonConvert.DeserializeObject<Dictionary<String, Object>>
            ((JsonConvert.DeserializeObject<Dictionary<String, Object>>
            ((JsonConvert.DeserializeObject<Dictionary<String, Object>>
            (jsonDict["dimension"].ToString()))[field_name].ToString()))
            ["category"].ToString()))["index"].ToString()).ToDictionary(x => x.Value, x => x.Key);
        }

        private String GetNaceCode(Dictionary<String, Object> jsonDict, List<int> indexes, List<String> naceRegionYearFields)
        {
            var nace = GetNestedField("nace_r2", jsonDict);
            return nace[indexes[naceRegionYearFields.IndexOf("nace_r2")]];
        }

        private String GetRegionCode(Dictionary<String, Object> jsonDict, List<int> indexes, List<String> naceRegionYearFields)
        {
            var geo = GetNestedField("geo", jsonDict);
            return geo[indexes[naceRegionYearFields.IndexOf("geo")]];
        }

        private int GetYear(Dictionary<String, Object> jsonDict, List<int> indexes, List<String> naceRegionYearFields)
        {
            var time = GetNestedField("time", jsonDict);
            return int.Parse(time[indexes[naceRegionYearFields.IndexOf("time")]]);
        }

        private List<int> findIndexesOfFields(int indexOfData, List<int> numberOfItemsInFields){
            List<int> indexes = new List<int>();

            //modulus operations to find the indexes of nace, region, and year in any order
            indexes.Add(indexOfData / (numberOfItemsInFields[1]*numberOfItemsInFields[2]));
            indexes.Add((indexOfData % (numberOfItemsInFields[1]*numberOfItemsInFields[2]) / numberOfItemsInFields[2]));
            indexes.Add((indexOfData % (numberOfItemsInFields[1]*numberOfItemsInFields[2])) % numberOfItemsInFields[2]);
            return indexes;
        }
        
    }
}