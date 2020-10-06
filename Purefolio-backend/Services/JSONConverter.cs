using System;
using Purefolio_backend.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;



namespace Purefolio_backend
{

    

    public class JSONConverter
    {    
        private readonly ILogger<EuroStatFetchService> _logger;

        public JSONConverter(ILogger<EuroStatFetchService> _logger)

        {
            this._logger = _logger;
        }
        

        public List<NaceRegionData> convert(String jsonString, String dataset){
            List<NaceRegionData> nrdList = new List<NaceRegionData>();
            List<string> IDinOrder = new List<string>();
            List<int> SizeinOrder = new List<int>();
            


            _logger.LogInformation(message:jsonString);

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

        
            
            List<int> indexes = new List<int>();
            foreach (KeyValuePair<string, string> entry in value)
            {
                indexes.Clear();

                int indexOfData = int.Parse(entry.Key);
                //modulus operations to find the indexes of nace, region, and year in any order
                indexes.Add(indexOfData / (SizeinOrder[1]*SizeinOrder[2]));
                indexes.Add((indexOfData % (SizeinOrder[1]*SizeinOrder[2]) / SizeinOrder[2]));
                indexes.Add((indexOfData % (SizeinOrder[1]*SizeinOrder[2])) % SizeinOrder[2]);

                string Nace = nace[indexes[IDinOrder.IndexOf("nace_r2")]];
                string Geo = geo[indexes[IDinOrder.IndexOf("geo")]];
                string Year = time[indexes[IDinOrder.IndexOf("time")]];

                _logger.LogInformation(message:"Value on index " + entry.Key +  ": " + entry.Value + ", Nace: " + Nace + ", Geo: " + Geo + ", Year: " + Year);
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