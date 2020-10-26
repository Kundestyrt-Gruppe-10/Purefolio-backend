using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;



namespace Purefolio_backend.Utils
{
    public class Field
    {
        public string name;
        public int jsonIndex; 
        public int totalElements;

        public Field(string name, int jsonIndex, int totalElements)
        {
            this.name = name;
            this.jsonIndex = jsonIndex;
            this.totalElements = totalElements;
        }
    }
    public class EuroStatJSONUnNester
    {    
        private string jsonString;
        private Dictionary<String, Object> jsonDict;
        private Dictionary<int, String> naces;
        private Dictionary<int, string> regions;
        private Dictionary<int, string> years;
        private List<Field> fields;

        private Dictionary<String, String> values;

        public EuroStatJSONUnNester(string jsonString){
            this.jsonString = jsonString;
            this.jsonDict = GetJsonDict();
            this.naces = GetNestedField("nace_r2");
            this.regions = GetNestedField("geo");
            this.years = GetNestedField("time");
            this.values = DeserializeValues();
            this.fields = CreateFields();
        }

        /// <summary>
        /// Deserializes and returns a field in the JSON object under dimension -> NAME_OF_THE_FIELD -> category -> index
        /// </summary>
        /// <param name="field_name">Name of the field in dimension to fetch information about.</param>
        /// <returns></returns>
        public Dictionary<int, String> GetNestedField(string field_name)
        {
            return JsonConvert.DeserializeObject<Dictionary<String, int>>
            ((JsonConvert.DeserializeObject<Dictionary<String, Object>>
            ((JsonConvert.DeserializeObject<Dictionary<String, Object>>
            ((JsonConvert.DeserializeObject<Dictionary<String, Object>>
            (jsonDict["dimension"].ToString()))[field_name].ToString()))
            ["category"].ToString()))["index"].ToString()).ToDictionary(x => x.Value, x => x.Key);
        }
        public String GetNaceCode(int naceId)
        {
            return naces[naceId];
        }

        public String GetRegionCode(int regionId)
        {
            return regions[regionId];
        }

        public int GetYear(int yearId)
        {
            return int.Parse(years[yearId]);
        }

        public Dictionary<String, Object> GetJsonDict()
        {
            return JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonString);
        }

        public Dictionary<String, String> GetValues()
        {
            return values;
        }

        public Dictionary<String, String> DeserializeValues()
        {
            return JsonConvert.DeserializeObject<Dictionary<String, String>>(GetJsonDict()["value"].ToString());
        }

        /// <summary>
        /// Returns a list of the names of the categories present in the JSON object.
        /// It is returned in the order they appear in the JSON object.
        /// </summary>
        /// <returns></returns>
        public List<String> GetID()
        {
            return JsonConvert.DeserializeObject<List<String>>(GetJsonDict()["id"].ToString());
        }

        /// <summary>
        /// Returns a list of sizes, that is how many elements there are in each category present in the JSON object. 
        /// It is returned in the order they appear in the JSON object.
        /// </summary>
        /// <returns></returns>
        public List<int> GetSize()
        {
            return JsonConvert.DeserializeObject<List<int>>(GetJsonDict()["size"].ToString());
        }

        public List<Field> GetFields()
        {
            return fields;
        }

        public int GetFieldIndex(string name)
        {
            return fields.FindIndex(match:field => field.name == name);
        }

        /// <summary>
        /// Creates a list of fields to be used to find the order of nace, geo, and time in the JSON object returned from Eurostat.
        /// It also stores how many elements there are in each category in the dataset.
        /// </summary>
        /// <returns></returns>
        public List<Field> CreateFields()
        {
            List<String> ids = GetID();
            List<int> sizes = GetSize();
            
            int naceIndex = ids.IndexOf("nace_r2");
            int regionIndex = ids.IndexOf("geo");
            int yearIndex = ids.IndexOf("time");            
            return new List<Field>(){
                new Field(name:"nace", jsonIndex:naceIndex, totalElements:sizes[naceIndex]),
                new Field(name:"region", jsonIndex:regionIndex, totalElements:sizes[regionIndex]),
                new Field(name:"year", jsonIndex:yearIndex, totalElements:sizes[yearIndex])
            }.OrderBy(field => field.jsonIndex).ToList();
        }

        /// <summary>
        /// Checks for valid dataset:
        /// * Not more than 1 element in categories except for nace, geo, and time.
        /// * Contains all three categories that are necessary.
        /// </summary>
        /// <returns></returns>
        public Boolean IsValidDataset()
        {
            List<String> id = GetID();
            List<int> size = GetSize();
            for (int i = 0; i < id.Count; i++)
            {   
                if (!(id.Contains("nace_r2") && id.Contains("geo") && id.Contains("time"))){
                    Console.WriteLine("Dataset invalid. It did not have all necessary fields.");
                    return false;
                }
                if (!(id[i].Equals("nace_r2") || id[i].Equals("geo") || id[i].Equals("time")) && !size[i].Equals(1))
                {
                    Console.WriteLine("Dataset invalid. " + id[i] + " did not have exactly 1 field.");
                    return false;
                }
            }
            return true;
        }
    }
}