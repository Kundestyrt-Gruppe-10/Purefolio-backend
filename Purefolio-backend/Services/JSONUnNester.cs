using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;



namespace Purefolio_backend
{
    public class JSONUnNester
    {    
        private string jsonString;
        private Dictionary<String, Object> jsonDict;

        private Dictionary<int, String> naces;

        private Dictionary<int, string> regions;

        private Dictionary<int, string> years;

        public JSONUnNester(string jsonString){
            this.jsonString = jsonString;
            this.jsonDict = GetJsonDict();
            this.naces = GetNestedField("nace_r2");
            this.regions = GetNestedField("geo");
            this.years = GetNestedField("time");
        }

        public Dictionary<int, String> GetNestedField(string field_name)
        {
            return JsonConvert.DeserializeObject<Dictionary<String, int>>
            ((JsonConvert.DeserializeObject<Dictionary<String, Object>>
            ((JsonConvert.DeserializeObject<Dictionary<String, Object>>
            ((JsonConvert.DeserializeObject<Dictionary<String, Object>>
            (jsonDict["dimension"].ToString()))[field_name].ToString()))
            ["category"].ToString()))["index"].ToString()).ToDictionary(x => x.Value, x => x.Key);
        }
        public String GetNaceCode(List<int> indexes, List<String> naceRegionYearFields)
        {
            return naces[indexes[naceRegionYearFields.IndexOf("nace_r2")]];
        }

        public String GetRegionCode(List<int> indexes, List<String> naceRegionYearFields)
        {
            return regions[indexes[naceRegionYearFields.IndexOf("geo")]];
        }

        public int GetYear(List<int> indexes, List<String> naceRegionYearFields)
        {
            return int.Parse(years[indexes[naceRegionYearFields.IndexOf("time")]]);
        }

        public Dictionary<String, Object> GetJsonDict()
        {
            return JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonString);
        }

        public Dictionary<String, String> GetValue()
        {
            return JsonConvert.DeserializeObject<Dictionary<String, String>>(GetJsonDict()["value"].ToString());
        }

        public List<String> GetID()
        {
            return JsonConvert.DeserializeObject<List<String>>(GetJsonDict()["id"].ToString());
        }

        public List<int> GetSize()
        {
            return JsonConvert.DeserializeObject<List<int>>(GetJsonDict()["size"].ToString());
        }

        public (List<String>, List<int>) MakeOrderedLists()
        {
            List<String> naceRegionYearFields = new List<String>();
            List<int> numberOfItemsInFields = new List<int>();

            List<String> id = GetID();

            for (int i = 0; i < id.Count; i++)
            {   
                if(id[i].Equals("nace_r2") || id[i].Equals("geo") || id[i].Equals("time"))
                {
                    naceRegionYearFields.Add(id[i]);
                    numberOfItemsInFields.Add(GetSize()[i]);
                }
            }
            return (naceRegionYearFields, numberOfItemsInFields);
        }
    }
}