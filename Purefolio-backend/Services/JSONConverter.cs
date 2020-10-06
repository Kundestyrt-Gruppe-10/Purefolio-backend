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
            var dimension = JsonConvert.DeserializeObject<Dictionary<string, Object>>(jsonDict["dimension"].ToString());
            var nace_r2_complex = JsonConvert.DeserializeObject<Dictionary<string, Object>>(dimension["nace_r2"].ToString());
            nace_r2_complex = JsonConvert.DeserializeObject<Dictionary<string, Object>>(nace_r2_complex["category"].ToString());
            var nace_r2 = JsonConvert.DeserializeObject<Dictionary<string, int>>(nace_r2_complex["index"].ToString());
            var inverted_nace_r2 = nace_r2.ToDictionary(x => x.Value, x => x.Key);
            var geo_complex = JsonConvert.DeserializeObject<Dictionary<string, Object>>(dimension["geo"].ToString());
            geo_complex = JsonConvert.DeserializeObject<Dictionary<string, Object>>(geo_complex["category"].ToString());
            var geo = JsonConvert.DeserializeObject<Dictionary<string, int>>(geo_complex["index"].ToString());
            var inverted_geo = geo.ToDictionary(x => x.Value, x => x.Key);
            var time_complex = JsonConvert.DeserializeObject<Dictionary<string, Object>>(dimension["time"].ToString());
            time_complex = JsonConvert.DeserializeObject<Dictionary<string, Object>>(time_complex["category"].ToString());
            var time = JsonConvert.DeserializeObject<Dictionary<string, int>>(time_complex["index"].ToString());
            var inverted_time = time.ToDictionary(x => x.Value, x => x.Key);


            //checks for valid dataset (not more than 1 element in categories except for nace, geo, and time)
            // TODO: Actually handle when datasets are wrong.

            for (int i = 0; i < id.Count; i++)
            {   
                if(id[i].Equals("nace_r2") || id[i].Equals("geo") || id[i].Equals("time"))
                {
                    IDinOrder.Add(id[i]);
                    SizeinOrder.Add(size[i]);
                }
                
                else{
                    if(!size[i].Equals(1)){
                        _logger.LogError(message:"Dataset invalid. " + id[i] + " did not have exactly 1 field.");
                    }
                }
            }

            
            List<int> indexes = new List<int>();
            foreach (KeyValuePair<string, string> entry in value)
            {
                indexes.Clear();

                int indexOfData = int.Parse(entry.Key);
                //modulus operations to find the indexes of nace, region, and year in any order
                indexes.Add(indexOfData / (SizeinOrder[1]*SizeinOrder[2]));
                indexes.Add((indexOfData % (SizeinOrder[1]*SizeinOrder[2]) / SizeinOrder[2]));
                indexes.Add((indexOfData % (SizeinOrder[1]*SizeinOrder[2])) % SizeinOrder[2]);

                string Nace = inverted_nace_r2[indexes[IDinOrder.IndexOf("nace_r2")]];
                string Geo = inverted_geo[indexes[IDinOrder.IndexOf("geo")]];
                string Year = inverted_time[indexes[IDinOrder.IndexOf("time")]];

                _logger.LogInformation(message:"Value on index " + entry.Key +  ": " + entry.Value + ", Nace: " + Nace + ", Geo: " + Geo + ", Year: " + Year);
            }

            return nrdList;
        }

        
    }
}