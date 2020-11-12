using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Purefolio_backend;
using Purefolio_backend.Controllers.Tests;
using System.Net.Http;
using System.Linq;



namespace Purefolio_backend.Accuracy.Tests
{
    [TestClass()]
    public class AccuracyTests
    {   
        static HttpClient client = new HttpClient();

        
        [TestMethod()]
        public async Task TestAccuracy()
        {
            Boolean hasDuplicateIDs = false;
            Boolean hasDuplicateData = false;
            

            String url1 = "http://localhost:5000/naces";
            String url2 = "http://localhost:5000/regions";

            HttpResponseMessage naces = await client.GetAsync(url1);
            int naceCount = naces.Content.ReadAsStringAsync().Result.Split('}').ToList().Count - 1;            
            Console.WriteLine("Number of Naces: " + naceCount);
            HttpResponseMessage regions = await client.GetAsync(url2);
            int regionCount = regions.Content.ReadAsStringAsync().Result.Split('}').ToList().Count - 1;            
            Console.WriteLine("Number of Regions: " + regionCount);

            List<int> naceregionids = new List<int>();

            for (int regionID = 1; regionID <= regionCount; regionID++)
            {
                for (int naceID = 1; naceID <= naceCount; naceID++)
                {
                    String url = "http://localhost:5000/naceregiondata/" + regionID + "/" + naceID;
                    HttpResponseMessage response = await client.GetAsync(url);
                    string list = response.Content.ReadAsStringAsync().Result;
                    List<int> years = new List<int>();

                    if(list != "[]"){
                        foreach (var item in list.Split(new string[] { "naceRegionDataId\":" }, StringSplitOptions.None))
                        {
                            string naceregiondataid = item.Split(',')[0];
                            if(naceregiondataid != "[{\""){
                                //Console.WriteLine("NRD ID: " + naceregiondataid);
                                naceregionids.Add(int.Parse(naceregiondataid));
                            }
                        }
                        foreach (var i in list.Split(new string[] { "year\"" }, StringSplitOptions.None))
                        {
                            if(i.StartsWith(":")){
                                string year = (i.Split(',')[0]).Substring(1);
                                //Console.WriteLine("Year: " + year);
                                years.Add(int.Parse(year));
                            }
                        }
                        
                    }
                    if(years.Count != years.Distinct().Count()){
                        Console.WriteLine("You have duplicates of the same data.");
                        hasDuplicateData = true;
                    }

                } 
            }
            if(naceregionids.Count != naceregionids.Distinct().Count()){
                Console.WriteLine("You have duplicates of the same ID.");
                hasDuplicateIDs = true;
            }
            Console.WriteLine("Number of IDs: " + naceregionids.Count);

            Assert.IsFalse(hasDuplicateData);
            Assert.IsFalse(hasDuplicateIDs);    
        }        
    }
}