using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Purefolio_backend.Models.Tests
{
    [TestClass()]
    public class NaceRegionDataTests
    {
        

        [TestMethod()]
        public void TestMerge()
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