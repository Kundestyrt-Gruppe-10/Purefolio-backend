using System;
using System.Collections.Generic;

namespace Purefolio_backend
{
    public class DataSetProperties
    {    

        private Dictionary<string, List<string>> filters;

        private List<String> naces = new List<string> {"A","A01","A02","A03","B","B05","B06","B07","B08","B09","C","C10","C11","C12","C13","C14","C15",
        "C16","C17","C18","C19","C20","C21","C22","C23","C24","C25","C26","C27","C28","C29","C30","C31","C32","C33","D","E","E36","E37","E38","E39","F",
        "F41","F42","F43","G","G45","G46","G47","H","H49","H50","H51","H52","H53","I","I55","I56","J",
        "J58","J59","J60","J61","J62","J63","K","K64","K65","K66","L","M","M69","M70","M71","M72","M73","M74","M75","N","N77","N78","N79","N80","N81",
        "N82","O","P","Q","Q86","Q87","Q88","R","R90","R91","R92","R93","S","S94","S95","S96","T","T97","T98","U"};

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




        public String getFilters(String tableID, int index){

            return "" + filters[tableID][1] + '&' + getTimeFilters() + '&' + getNaceFilters(index);
        }

        private String getTimeFilters(){
            return "time=" + string.Join("&time=", years);
        }

        private String getNaceFilters(int index)
        {
            int start = index * 50;
            int end = 50;

            if (naces.Count < end * (index + 1)) {
                end = naces.Count - (index * 50);
            }

            List<String> queryNaces = naces.GetRange(start, end);
            return "nace_r2=" + string.Join("&nace_r2=", queryNaces);
        }

        public String getTableCode(string tableID){
            return filters[tableID][0];
        }


        public Dictionary<string, List<string>>.KeyCollection GetTableIDs(){
            return filters.Keys;
        }

        public int GetFetchIterationsCount() 
        {
            int iterations = (int)Math.Ceiling((decimal)naces.Count / (decimal)50);
            
            return iterations;
        }
        
    }
}