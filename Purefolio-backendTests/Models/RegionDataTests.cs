using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq; 

namespace Purefolio_backend.Models.Tests
{
    [TestClass()]
    public class RegionDataTests
    {
        [TestMethod()]
        public void ObjectsShouldHaveRightAmountOfAttributes()
        {
            int testRegionId = 1;
            int testYear = 2020;

            RegionData nrd = new RegionData(){regionId = testRegionId, year = testYear};
            
            List<System.Reflection.PropertyInfo> props = nrd.GetType().GetProperties().ToList(); 

            Assert.AreEqual(props.Count(),7); 
        }

        [TestMethod()]
        public void AttributesShouldBeNullable()
        {
            int testRegionId = 1;
            int testYear = 2020;

            RegionData nrd = new RegionData(){regionId = testRegionId, year = testYear};
            
            List<System.Reflection.PropertyInfo> props = nrd.GetType().GetProperties().ToList(); 

            List<string> requiredFields = new List<string>(){"regionDataId", "region", "regionId", "year"};

            foreach (System.Reflection.PropertyInfo prop in props)
            {
                if(!requiredFields.Contains(prop.Name))
                {
                    Assert.AreEqual(prop.GetValue(nrd), null);
                }
                
            }
        }
        
        [TestMethod()]
        public void ObjectsShouldMergeProperties()
        {
            int testRegionId = 0;
            int testYear = 2020;
            int testCorruptionRate = 80;
            int testPopulation = 80000000;

            RegionData rd1 = new RegionData(){regionId = testRegionId, year=testYear, corruptionRate = testCorruptionRate};
            RegionData rd2 = new RegionData(){regionId = testRegionId, year=testYear, population = testPopulation};
            RegionData rdCombined = new RegionData(){regionId = testRegionId, year=testYear, corruptionRate = testCorruptionRate, population = testPopulation};

            RegionData rdMerged = rd1.merge(rd2);
            
            Assert.AreEqual(rdCombined, rdMerged);
        }
    }
}