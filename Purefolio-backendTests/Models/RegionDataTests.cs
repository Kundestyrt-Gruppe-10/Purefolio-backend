using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq; 

namespace Purefolio_backend.Models.Tests
{
    [TestClass()]
    public class RegionDataTests
    {

        private RegionData rd1WithCorruptionData;
        private RegionData rd1WithPopulationData;
        private RegionData rd2;
        private RegionData rd1WithCorruptionAndPopulationData;
        private RegionData rd2WithoutData;
        private List<string> requiredFields;

        private int regionId1 = 1;
        private int regionId2 = 2;
        private int testYear = 2020;
        private int testCorruptionRate = 80;
        private int testPopulation = 80000000;

         

        [TestInitialize()]
        public void Setup()
        {
            rd1WithCorruptionData = new RegionData(){regionId = regionId1, year=testYear, corruptionRate = testCorruptionRate};
            rd1WithPopulationData = new RegionData(){regionId = regionId1, year=testYear, population = testPopulation};
            rd1WithCorruptionAndPopulationData = new RegionData(){regionId = regionId1, year=testYear, corruptionRate = testCorruptionRate, population = testPopulation};
            rd2WithoutData = new RegionData(){regionId = regionId2, year = testYear};
            requiredFields = new List<string>(){"regionDataId", "region", "regionId", "year"};
        }
        
        [TestMethod()]
        public void ObjectsShouldHaveRightAmountOfAttributes()
        {
            List<System.Reflection.PropertyInfo> props = rd2WithoutData.GetType().GetProperties().ToList(); 
            Assert.AreEqual(props.Count(),7); 
        }

        [TestMethod()]
        public void AttributesShouldBeNullable()
        {
            
           List<System.Reflection.PropertyInfo> props = rd2WithoutData.GetType().GetProperties().ToList();

            foreach (System.Reflection.PropertyInfo prop in props)
            {
                if(!requiredFields.Contains(prop.Name))
                {
                    Assert.AreEqual(prop.GetValue(rd2WithoutData), null);
                }
                
            }
        }
        
        [TestMethod()]
        public void ObjectsShouldMergeProperties()
        {
            RegionData rdMerged = rd1WithCorruptionData.merge(rd1WithPopulationData);
            Assert.AreEqual(rd1WithCorruptionAndPopulationData, rdMerged);
        }

        [TestMethod()]
        public void ObjectsShouldBeEqualWhenSameIdsAndYears()
        {
            Assert.AreEqual(rd1WithCorruptionData,rd1WithPopulationData);
        }

        [TestMethod()]
        [DataRow(1,2)]
        public void ObjectsShouldNotBeEqualWhenDifferentIds(int id1, int id2)
        {
            RegionData rd1 = new RegionData(){regionId = id1, year=testYear };
            RegionData rd2 = new RegionData(){regionId = id2, year=testYear };  
            Assert.AreNotEqual(rd1,rd2);
        }

        [TestMethod()]
        [DataRow(2020,2019)]
        public void ObjectsShouldNotBeEqualWhenDifferentYears(int year1, int year2)
        {
            RegionData rd1 = new RegionData(){regionId = regionId1, year=year1 };
            RegionData rd2 = new RegionData(){regionId = regionId2, year=year2 };
            Assert.AreNotEqual(rd1,rd2);
        }

        [TestMethod()]
        [DataRow(2020,2019)]
        public void ObjectsShouldNotMergeWhenDifferentYears(int year1, int year2)
        {
            RegionData rd1 = new RegionData(){regionId = regionId1, year=year1 };
            RegionData rd2 = new RegionData(){regionId = regionId2, year=year2, corruptionRate = 80};
            
            RegionData rdMerged = rd1.merge(rd2);

            Assert.AreEqual(rd1,rdMerged);
        }

        [TestMethod()]
        [DataRow(1,2)]
        public void ObjectsShouldNotMergeWhenDifferentIds(int id1, int id2)
        {
            RegionData rd1 = new RegionData(){regionId = id1, year=testYear };
            RegionData rd2 = new RegionData(){regionId = id2, year=testYear, corruptionRate = 80};
            
            RegionData rdMerged = rd1.merge(rd2);

            Assert.AreEqual(rd1,rdMerged);
        }
    }
}