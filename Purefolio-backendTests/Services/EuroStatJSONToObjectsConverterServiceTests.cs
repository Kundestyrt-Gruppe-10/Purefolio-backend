using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Moq;
using Purefolio_backend.Models;





namespace Purefolio_backend.Services.Tests
{
    [TestClass()]
    public class JSONConverterTests
    {
        private EuroStatJSONToObjectsConverterService jsc;
        private string tooManyFields = "{\"version\":\"2.0\",\"label\":\"Non-fatal accidents at work by NACE Rev. 2 activity and age\",\"href\":\"http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/hsw_n2_03?precision=1&geo=AT&geo=BE&unit=RT_INC&time=2015&time=2016&time=2017&time=2018&age=TOTAL&age=Y_LT18&nace_r2=A&nace_r2=B\",\"source\":\"Eurostat\",\"updated\":\"2020-08-18\",\"extension\":{\"datasetId\":\"hsw_n2_03\",\"lang\":\"EN\",\"description\":null,\"subTitle\":null},\"class\":\"dataset\",\"value\":{\"0\":2099.4,\"1\":4846.39,\"2\":5324.84,\"3\":2770.94,\"4\":625.57,\"5\":1786.03,\"6\":1765.78,\"7\":1668.13,\"8\":1125.35,\"9\":1174,\"10\":1339.59,\"11\":2262.16,\"12\":1390.07,\"13\":0,\"14\":3660.34,\"15\":0,\"16\":2221.57,\"17\":1678.7,\"18\":2479.12,\"19\":2579.59,\"20\":2225.37,\"21\":3725.66,\"22\":3480.08,\"23\":3212.52,\"24\":0,\"25\":0,\"26\":1629.73,\"27\":0,\"28\":0,\"29\":0,\"30\":0,\"31\":0},\"dimension\":{\"unit\":{\"label\":\"unit\",\"category\":{\"index\":{\"RT_INC\":0},\"label\":{\"RT_INC\":\"Incidence rate\"}}},\"nace_r2\":{\"label\":\"nace_r2\",\"category\":{\"index\":{\"A\":0,\"B\":1},\"label\":{\"A\":\"Agriculture, forestry and fishing\",\"B\":\"Mining and quarrying\"}}},\"age\":{\"label\":\"age\",\"category\":{\"index\":{\"TOTAL\":0,\"Y_LT18\":1},\"label\":{\"TOTAL\":\"Total\",\"Y_LT18\":\"Less than 18 years\"}}},\"geo\":{\"label\":\"geo\",\"category\":{\"index\":{\"AT\":0,\"BE\":1},\"label\":{\"AT\":\"Austria\",\"BE\":\"Belgium\"}}},\"time\":{\"label\":\"time\",\"category\":{\"index\":{\"2015\":0,\"2016\":1,\"2017\":2,\"2018\":3},\"label\":{\"2015\":\"2015\",\"2016\":\"2016\",\"2017\":\"2017\",\"2018\":\"2018\"}}}},\"id\":[\"unit\",\"nace_r2\",\"age\",\"geo\",\"time\"],\"size\":[1,2,2,2,4]}";
        private string validJSON = "{\"version\":\"2.0\",\"label\":\"Non-fatal accidents at work by NACE Rev. 2 activity and age\",\"href\":\"http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/hsw_n2_03?precision=1&geo=AT&geo=BE&unit=RT_INC&time=2015&time=2016&time=2017&time=2018&age=TOTAL&nace_r2=A&nace_r2=B\",\"source\":\"Eurostat\",\"updated\":\"2020-08-18\",\"extension\":{\"datasetId\":\"hsw_n2_03\",\"lang\":\"EN\",\"description\":null,\"subTitle\":null},\"class\":\"dataset\",\"value\":{\"0\":2099.4,\"1\":4846.39,\"2\":5324.84,\"3\":2770.94,\"4\":625.57,\"5\":1786.03,\"6\":1765.78,\"7\":1668.13,\"8\":2221.57,\"9\":1678.7,\"10\":2479.12,\"11\":2579.59,\"12\":2225.37,\"13\":3725.66,\"14\":3480.08,\"15\":3212.52},\"dimension\":{\"unit\":{\"label\":\"unit\",\"category\":{\"index\":{\"RT_INC\":0},\"label\":{\"RT_INC\":\"Incidence rate\"}}},\"nace_r2\":{\"label\":\"nace_r2\",\"category\":{\"index\":{\"A\":0,\"B\":1},\"label\":{\"A\":\"Agriculture, forestry and fishing\",\"B\":\"Mining and quarrying\"}}},\"age\":{\"label\":\"age\",\"category\":{\"index\":{\"TOTAL\":0},\"label\":{\"TOTAL\":\"Total\"}}},\"geo\":{\"label\":\"geo\",\"category\":{\"index\":{\"AT\":0,\"BE\":1},\"label\":{\"AT\":\"Austria\",\"BE\":\"Belgium\"}}},\"time\":{\"label\":\"time\",\"category\":{\"index\":{\"2015\":0,\"2016\":1,\"2017\":2,\"2018\":3},\"label\":{\"2015\":\"2015\",\"2016\":\"2016\",\"2017\":\"2017\",\"2018\":\"2018\"}}}},\"id\":[\"unit\",\"nace_r2\",\"age\",\"geo\",\"time\"],\"size\":[1,2,1,2,4]}";
        List<int> size = new List<int>(){8,36,4};

        private Region austria = new Region() { regionCode = "AT", regionName = "Austria", area = 83858 };
        private Region belgium = new Region() { regionCode = "BE", regionName = "Belgium", area = 30510 };
        private Nace a = new Nace() {  naceCode = "A", naceName = "Agriculture, forestry and fishing" };
        private Nace b = new Nace() {  naceCode = "B", naceName = "Mining and quarrying" };
        private List<Nace> allNaces;
        private List<Region> allRegions;
        private Mock<ILogger<JsonConverter>> mockLogger;
        private Mock<IDatabaseStore> mockDBS;



        
        [TestInitialize()]
        public void Setup()
        {
            mockLogger = new Mock<ILogger<JsonConverter>>();
            mockDBS = new Mock<IDatabaseStore>();

            jsc = new EuroStatJSONToObjectsConverterService(mockLogger.Object, mockDBS.Object);

            allRegions = new List<Region>(){austria, belgium};
            allNaces = new List<Nace>(){a,b};
            
            mockDBS.Setup(x => x.getAllRegions()).Returns(allRegions);
            mockDBS.Setup(x => x.getAllNaces()).Returns(allNaces);
            mockDBS.Setup(x => x.getAllNaceRegionData()).Returns(new List<NaceRegionData>());
            mockDBS.Setup(x => x.addNaceRegionData(new List<NaceRegionData>())).Returns(new List<NaceRegionData>());
        }
        
        [TestMethod()]
        public void ShouldReturnEmptyListForInvalidDataset()
        {
            List<NaceRegionData> result = jsc.Convert(tooManyFields, "workAccidentsIncidentRate");
            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod()]
        public void ShouldReturnNaceRegionListForValidDataset()
        {
            List<NaceRegionData> result = jsc.Convert(validJSON, "workAccidentsIncidentRate");
            CollectionAssert.AreNotEqual(result, new List<NaceRegionData>());
        }


        [TestMethod()]
        [DataRow(374, 2, 21, 2)]
        [DataRow(1078, 7, 17, 2)]
        public void FindIndexesOfFieldsShouldReturnListWithCorrectOrderedIndexesForFields(int euindex, int i1, int i2, int i3)
        {
            List<int> indexes = jsc.findIndexesOfFields(euindex, size);
            List<int> trueResult = new List<int>(){i1, i2, i3};
            CollectionAssert.Equals(trueResult, indexes);
        }
    }
}