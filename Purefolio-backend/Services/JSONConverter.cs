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
        

        public List<NaceRegionData> convert(String jsonString, String attributeName){
            List<NaceRegionData> nrdList = new List<NaceRegionData>();
            List<string> IDinOrder = new List<string>();
            List<int> SizeinOrder = new List<int>();
            

            // Getting fields in the nested JSON file
            var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, Object>>(jsonString);
            var value = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonDict["value"].ToString());
            var id = JsonConvert.DeserializeObject<List<string>>(jsonDict["id"].ToString());
            var size = JsonConvert.DeserializeObject<List<int>>(jsonDict["size"].ToString());
            var nace = getNestedField("nace_r2", jsonDict);
            var geo = getNestedField("geo", jsonDict);
            var time = getNestedField("time", jsonDict);

            CheckValidDataset(id, size);

            (IDinOrder, SizeinOrder) = MakeOrderedLists(id, size);

            List<Region> regions = databaseStore.getAllRegions();
            List<Nace> naces = databaseStore.getAllNaces();
            
            List<int> indexes = new List<int>();
            foreach (KeyValuePair<string, string> entry in value)
            {
                
                indexes.Clear();

                int indexOfData = int.Parse(entry.Key);
                //modulus operations to find the indexes of nace, region, and year in any order
                indexes.Add(indexOfData / (SizeinOrder[1]*SizeinOrder[2]));
                indexes.Add((indexOfData % (SizeinOrder[1]*SizeinOrder[2]) / SizeinOrder[2]));
                indexes.Add((indexOfData % (SizeinOrder[1]*SizeinOrder[2])) % SizeinOrder[2]);

                string naceCode = nace[indexes[IDinOrder.IndexOf("nace_r2")]];
                string regionCode = geo[indexes[IDinOrder.IndexOf("geo")]];

                int year = int.Parse(time[indexes[IDinOrder.IndexOf("time")]]);
                double propValue = double.Parse(entry.Value, CultureInfo.InvariantCulture);


                Nace nace1 = naces.Find(nace => nace.naceCode == naceCode);
                Region region = regions.Find(region => region.regionCode == regionCode);

                if (nace != null && region != null){
            
                    NaceRegionData nrd = new NaceRegionData(){naceId=nace1.naceId, regionId=region.regionId, year=year};
                    Type type = nrd.GetType();

                    PropertyInfo prop = type.GetProperty(attributeName);

                    prop.SetValue (nrd, propValue, null);
                    nrdList.Add(nrd);
                }                
            }
            return nrdList;
        }



        private void CheckValidDataset(List<string> id, List<int> size){
            //checks for valid dataset (not more than 1 element in categories except for nace, geo, and time)
            // TODO: Actually handle when datasets are wrong.

            for (int i = 0; i < id.Count; i++)
            {   
                if (!(id[i].Equals("nace_r2") || id[i].Equals("geo") || id[i].Equals("time")) && !size[i].Equals(1)){
                        _logger.LogError(message:"Dataset invalid. " + id[i] + " did not have exactly 1 field.");
                }
            }
        }

        private (List<string>, List<int>) MakeOrderedLists(List<string> id, List<int> size){
            List<string> IDinOrder = new List<string>();
            List<int> SizeinOrder = new List<int>();

            for (int i = 0; i < id.Count; i++)
            {   
                if(id[i].Equals("nace_r2") || id[i].Equals("geo") || id[i].Equals("time"))
                {
                    IDinOrder.Add(id[i]);
                    SizeinOrder.Add(size[i]);
                }
            }
            return (IDinOrder, SizeinOrder);
        }

        private Dictionary<int, string> getNestedField(string field_name, Dictionary<string, Object> jsonDict){
            var dimension = JsonConvert.DeserializeObject<Dictionary<string, Object>>(jsonDict["dimension"].ToString());
            var temp_field = JsonConvert.DeserializeObject<Dictionary<string, Object>>(dimension[field_name].ToString());
            temp_field = JsonConvert.DeserializeObject<Dictionary<string, Object>>(temp_field["category"].ToString());
            var field = JsonConvert.DeserializeObject<Dictionary<string, int>>(temp_field["index"].ToString());
            return field.ToDictionary(x => x.Value, x => x.Key);
        }
        
    }
}