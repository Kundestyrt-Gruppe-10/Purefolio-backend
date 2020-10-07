using System;
using System.Collections.Generic;

namespace Purefolio_backend
{
    public class DataSetProperties
    {    

        private Dictionary<string, List<string>> filters;
        private List<String> naces = new List<string> {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U"};
        private List<int> years = new List<int> {2015,2016,2017,2018};


        public DataSetProperties()
        {
            filters = new Dictionary<string, List<string>>();
            filters.Add("emissionPerYear", new List<string>{"env_ac_ainah_r2", "unit=KG_HAB&airpol=GHG"}); 
            filters.Add("workAccidentsIncidentRate", new List<string>{"hsw_n2_03", "unit=RT_INC&age=TOTAL"}); 
            filters.Add("genderPayGap", new List<string>{"earn_gr_gpgr2", "unit=PC"}); 
            filters.Add("environmentTaxes", new List<string>{"env_ac_taxind2", "tax=ENV&unit=MIO_EUR"}); 
            filters.Add("fatalAccidentsAtWork", new List<string>{"hsw_n2_02", "unit=RT_INC"});
            filters.Add("temporaryemployment", new List<string>{"lfsa_etgan2", "sex=T&unit=THS&age=Y15-74"}); 
            filters.Add("employeesPrimaryEducation", new List<string>{"edat_lfs_9910", "sex=T&unit=PC&isced11=ED0-2&age=Y15-74"}); 
            filters.Add("employeesSecondaryEducation", new List<string>{"edat_lfs_9910", "sex=T&unit=PC&isced11=ED3_4&age=Y15-74"}); 
            filters.Add("employeesTertiaryEducation", new List<string>{"edat_lfs_9910", "sex=T&unit=PC&isced11=ED5-8&age=Y15-74"}); 
        }




        public String getFilters(String tableID){
            return "" + filters[tableID][1] + '&' + getTimeFilters() + '&' + getNaceFilters();
        }

        private String getTimeFilters(){
            return "time=" + string.Join("&time=", years);
        }

        private String getNaceFilters()
        {
            return "nace_r2=" + string.Join("&nace_r2=", naces);
        }

        public String getTableCode(string tableID){
            return filters[tableID][0];
        }


        public Dictionary<string, List<string>>.KeyCollection GetTableIDs(){
            return filters.Keys;
        }
        
    }
}