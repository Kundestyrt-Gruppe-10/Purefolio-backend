using System;
using System.Collections.Generic;

namespace Purefolio_backend
{
    public class DataSetProperties
    {    

       
        private int max_elements = 50;

        private List<String> naces = new List<string> {"A","A01","A02","A03","B","B05","B06","B07","B08","B09","C","C10","C11","C12","C13","C14","C15",
        "C16","C17","C18","C19","C20","C21","C22","C23","C24","C25","C26","C27","C28","C29","C30","C31","C32","C33","D","E","E36","E37","E38","E39","F",
        "F41","F42","F43","G","G45","G46","G47","H","H49","H50","H51","H52","H53","I","I55","I56","J",
        "J58","J59","J60","J61","J62","J63","K","K64","K65","K66","L","M","M69","M70","M71","M72","M73","M74","M75","N","N77","N78","N79","N80","N81",
        "N82","O","P","Q","Q86","Q87","Q88","R","R90","R91","R92","R93","S","S94","S95","S96","T","T97","T98","U"};

        private List<int> years = new List<int> {2015,2016,2017,2018};


       
        
        public String getTimeFilters(){
            return "time=" + string.Join("&time=", years);
        }

        public String getNaceFilters(int index)
        {
            int start = index * max_elements;
            int end = max_elements;

            if (naces.Count < end * (index + 1)) {
                end = naces.Count - (index * max_elements);
            }
            List<String> queryNaces = naces.GetRange(start, end);
            return "nace_r2=" + string.Join("&nace_r2=", queryNaces);
        }

        
        
        public int GetFetchIterationsCount() 
        {
            int iterations = (int)Math.Ceiling((decimal)naces.Count / (decimal)max_elements);
            return iterations;
        }
        
    }
}