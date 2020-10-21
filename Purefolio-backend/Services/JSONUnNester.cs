using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;



namespace Purefolio_backend
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
    public class JSONUnNester
    {    
        private string jsonString;
        private Dictionary<String, Object> jsonDict;
        private Dictionary<int, String> naces;
        private Dictionary<int, string> regions;
        private Dictionary<int, string> years;
        private List<Field> fields;

        private Dictionary<String, String> values;

        public JSONUnNester(string jsonString){
            this.jsonString = jsonString;
            this.jsonDict = GetJsonDict();
            this.naces = GetNestedField("nace_r2");
            this.regions = GetNestedField("geo");
            this.years = GetNestedField("time");
            this.values = DeserializeValues();
            this.fields = CreateFields();
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

        public Dictionary<String, String> GetValues()
        {
            return values;
        }

        public Dictionary<String, String> DeserializeValues()
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