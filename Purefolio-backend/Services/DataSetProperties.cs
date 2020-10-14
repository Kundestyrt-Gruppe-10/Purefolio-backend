using System;
using System.Collections.Generic;

namespace Purefolio_backend
{
    public class DataSetProperties
    {    

       
        private int max_elements = 50;

        private List<int> years = new List<int> {2015,2016,2017,2018};


       
        
        public String getTimeFilters(){
            return "time=" + string.Join("&time=", years);
        }
    }
}