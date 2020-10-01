using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Purefolio_backend.Models.Tests
{
    [TestClass()]
    public class RegionDataTests
    {
        

        [TestMethod()]
        public void TestMerge()
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