using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq; 

namespace Purefolio_backend.Models.Tests
{
    [TestClass()]
    public class NaceRegionDataTests
    {

        private NaceRegionData nrd1WithEmissionPerYear;
        private NaceRegionData nrd1WithGenderPayGap;
        private NaceRegionData nrd1WithEmissionAndGenderPayGap;
        private NaceRegionData nrd2WithoutData;
        private List<string> requiredFields;

        private int regionId1 = 1;
        private int regionId2 = 2;

        private int naceId1 = 1;
        private int testYear = 2020;
        private int testGenderPayGap = 4;
        private int testEmissionPerYer = 80000000;

         

        [TestInitialize()]
        public void Setup()
        {
            nrd1WithEmissionPerYear = new NaceRegionData(){naceId = naceId1, regionId = regionId1, year=testYear, emissionPerYear = testEmissionPerYer };
            nrd1WithGenderPayGap = new NaceRegionData(){naceId = naceId1,regionId = regionId1, year=testYear, genderPayGap = testGenderPayGap };
            nrd1WithEmissionAndGenderPayGap = new NaceRegionData(){naceId = naceId1, regionId = regionId1, year=testYear, genderPayGap = testGenderPayGap,emissionPerYear = testEmissionPerYer};
            nrd2WithoutData = new NaceRegionData(){regionId = regionId2, year = testYear};
            requiredFields = new List<string>(){"naceRegionDataId", "region", "regionId", "nace", "naceId", "year"};
        }
        
        [TestMethod()]
        public void ObjectsShouldHaveRightAmountOfAttributes()
        {
            List<System.Reflection.PropertyInfo> props = nrd2WithoutData.getDataProperties(); 
            Assert.AreEqual(props.Count(), 14); 
        }

        [TestMethod()]
        public void AttributesShouldBeNullable()
        {
            
           List<System.Reflection.PropertyInfo> props = nrd2WithoutData.GetType().GetProperties().ToList();

            foreach (System.Reflection.PropertyInfo prop in props)
            {
                if(!requiredFields.Contains(prop.Name))
                {
                    Assert.AreEqual(prop.GetValue(nrd2WithoutData), null);
                }
                
            }
        }
        
        [TestMethod()]
        public void ObjectsShouldMergeProperties()
        {
            NaceRegionData rdMerged = nrd1WithGenderPayGap.merge(nrd1WithEmissionPerYear);
            Assert.AreEqual(nrd1WithEmissionAndGenderPayGap, rdMerged);
        }

        [TestMethod()]
        public void ObjectsShouldBeEqualWhenSameIdsAndYears()
        {
            Assert.AreEqual(nrd1WithGenderPayGap,nrd1WithEmissionPerYear);
        }

        [TestMethod()]
        [DataRow(1,2)]
        public void ObjectsShouldNotBeEqualWhenDifferentRegionIds(int id1, int id2)
        {
            NaceRegionData rd1 = new NaceRegionData(){regionId = id1, naceId = naceId1, year=testYear };
            NaceRegionData rd2 = new NaceRegionData(){regionId = id2, naceId = naceId1, year=testYear };  
            Assert.AreNotEqual(rd1,rd2);
        }

        [TestMethod()]
        [DataRow(1,2)]
        public void ObjectsShouldNotBeEqualWhenDifferentNaceIds(int id1, int id2)
        {
            NaceRegionData rd1 = new NaceRegionData(){naceId = id1, regionId = regionId1, year=testYear };
            NaceRegionData rd2 = new NaceRegionData(){naceId = id2, regionId = regionId1, year=testYear };  
            Assert.AreNotEqual(rd1,rd2);
        }

        [TestMethod()]
        [DataRow(2020,2019)]
        public void ObjectsShouldNotBeEqualWhenDifferentYears(int year1, int year2)
        {
            NaceRegionData nrd1 = new NaceRegionData(){year = year1, regionId = regionId1, naceId = naceId1 };
            NaceRegionData nrd2 = new NaceRegionData(){year = year2, regionId = regionId2, naceId = naceId1 };
            Assert.AreNotEqual(nrd1,nrd2);
        }

        [TestMethod()]
        [DataRow(2020,2019)]
        public void ObjectsShouldNotMergeWhenDifferentYears(int year1, int year2)
        {
            NaceRegionData nrd1 = new NaceRegionData(){year=year1, regionId = regionId1, naceId = naceId1 };
            NaceRegionData nrd2 = new NaceRegionData(){year=year2, regionId = regionId2, naceId = naceId1, emissionPerYear = testEmissionPerYer};
            
            NaceRegionData nrdMerged = nrd1.merge(nrd2);

            Assert.AreEqual(nrd1,nrdMerged);
        }

        [TestMethod()]
        [DataRow(1,2)]
        public void ObjectsShouldNotMergeWhenDifferentRegionIds(int id1, int id2)
        {
            NaceRegionData nrd1 = new NaceRegionData(){regionId = id1, naceId = naceId1, year=testYear };
            NaceRegionData nrd2 = new NaceRegionData(){regionId = id2, naceId = naceId1, year=testYear, emissionPerYear = testEmissionPerYer};
            
            NaceRegionData nrdMerged = nrd1.merge(nrd2);

            Assert.AreEqual(nrd1,nrdMerged);
        }

        [TestMethod()]
        [DataRow(1,2)]
        public void ObjectsShouldNotMergeWhenDifferentNaceIds(int id1, int id2)
        {
            NaceRegionData nrd1 = new NaceRegionData(){naceId = id1, regionId = regionId1,  year=testYear };
            NaceRegionData nrd2 = new NaceRegionData(){naceId = id2, regionId = regionId1,  year=testYear, emissionPerYear = testEmissionPerYer};
            
            NaceRegionData nrdMerged = nrd1.merge(nrd2);

            Assert.AreEqual(nrd1,nrdMerged);
        }
    }
}