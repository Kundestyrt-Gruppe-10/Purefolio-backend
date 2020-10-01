using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq; 

namespace Purefolio_backend.Models.Tests
{
    [TestClass()]
    public class NaceRegionDataTests
    {

        [TestMethod()]
        public void ObjectsShouldHaveRightAmountOfAttributes()
        {
            int testRegionId = 1;
            int testNaceId = 1;
            int testYear = 2020;

             NaceRegionData nrd = new NaceRegionData(){regionId = testRegionId, naceId = testNaceId, year = testYear};
            
            List<System.Reflection.PropertyInfo> props = nrd.GetType().GetProperties().ToList(); 
            List<System.Reflection.PropertyInfo> expected = new List<System.Reflection.PropertyInfo>();

            List<string> requiredFields = new List<string>(){"naceRegionDataId", "region", "regionId", "nace", "naceId", "year"};

            Assert.AreEqual(props.Count(),8); 
        }

        [TestMethod()]
        public void AttributesShouldBeNullable()
        {
            int testRegionId = 1;
            int testNaceId = 1;
            int testYear = 2020;

             NaceRegionData nrd = new NaceRegionData(){regionId = testRegionId, naceId = testNaceId, year = testYear};
            
            List<System.Reflection.PropertyInfo> props = nrd.GetType().GetProperties().ToList(); 
            List<System.Reflection.PropertyInfo> expected = new List<System.Reflection.PropertyInfo>();

            List<string> requiredFields = new List<string>(){"naceRegionDataId", "region", "regionId", "nace", "naceId", "year"};

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
            int testEmissionPerYear = 100;
            int testGenderPayGap = 100;


            NaceRegionData nrd1 = new NaceRegionData(){regionId = testRegionId, year=testYear, emissionPerYer = testEmissionPerYear};
            NaceRegionData nrd2 = new NaceRegionData(){regionId = testRegionId, year=testYear, genderPayGap = testGenderPayGap};
            NaceRegionData nrdCombined = new NaceRegionData(){regionId = testRegionId, year=testYear, emissionPerYer = testEmissionPerYear, genderPayGap = testGenderPayGap};

            NaceRegionData nrdMerged = nrd1.merge(nrd2);
            
            Assert.AreEqual(nrdMerged, nrdCombined);
        }
    }
}