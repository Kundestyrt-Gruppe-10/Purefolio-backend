using System;
using System.Collections.Generic;

namespace Purefolio_backend
{
    public class DataSetProperties
    {    
        private List<String> naces = new List<string> {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U"};
        private List<int> years = new List<int> {2015,2016,2017,2018};


        public String getTimeFilters(){
            return "time=" + string.Join("&time=", years);
        }

        public String getNaceFilters()
        {
            return "nace_r2=" + string.Join("&nace_r2=", naces);
        }        
    }
}