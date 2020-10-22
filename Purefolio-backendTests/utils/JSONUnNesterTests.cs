using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Moq;
using Purefolio_backend.Utils;

namespace Purefolio_backend.Utils.Tests
{
    [TestClass()]
    public class JSONUnNesterTests
    {
        private EuroStatJSONUnNester jun2;
        private EuroStatJSONUnNester jun1;
        private string json1 = "{\"version\":\"2.0\",\"label\":\"Non-fatal accidents at work by NACE Rev. 2 activity and age\",\"href\":\"http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/hsw_n2_03?precision=1&geo=AT&geo=BE&unit=RT_INC&time=2015&time=2016&time=2017&time=2018&age=TOTAL&age=Y_LT18&nace_r2=A&nace_r2=B\",\"source\":\"Eurostat\",\"updated\":\"2020-08-18\",\"extension\":{\"datasetId\":\"hsw_n2_03\",\"lang\":\"EN\",\"description\":null,\"subTitle\":null},\"class\":\"dataset\",\"value\":{\"0\":2099.4,\"1\":4846.39,\"2\":5324.84,\"3\":2770.94,\"4\":625.57,\"5\":1786.03,\"6\":1765.78,\"7\":1668.13,\"8\":1125.35,\"9\":1174,\"10\":1339.59,\"11\":2262.16,\"12\":1390.07,\"13\":0,\"14\":3660.34,\"15\":0,\"16\":2221.57,\"17\":1678.7,\"18\":2479.12,\"19\":2579.59,\"20\":2225.37,\"21\":3725.66,\"22\":3480.08,\"23\":3212.52,\"24\":0,\"25\":0,\"26\":1629.73,\"27\":0,\"28\":0,\"29\":0,\"30\":0,\"31\":0},\"dimension\":{\"unit\":{\"label\":\"unit\",\"category\":{\"index\":{\"RT_INC\":0},\"label\":{\"RT_INC\":\"Incidence rate\"}}},\"nace_r2\":{\"label\":\"nace_r2\",\"category\":{\"index\":{\"A\":0,\"B\":1},\"label\":{\"A\":\"Agriculture, forestry and fishing\",\"B\":\"Mining and quarrying\"}}},\"age\":{\"label\":\"age\",\"category\":{\"index\":{\"TOTAL\":0,\"Y_LT18\":1},\"label\":{\"TOTAL\":\"Total\",\"Y_LT18\":\"Less than 18 years\"}}},\"geo\":{\"label\":\"geo\",\"category\":{\"index\":{\"AT\":0,\"BE\":1},\"label\":{\"AT\":\"Austria\",\"BE\":\"Belgium\"}}},\"time\":{\"label\":\"time\",\"category\":{\"index\":{\"2015\":0,\"2016\":1,\"2017\":2,\"2018\":3},\"label\":{\"2015\":\"2015\",\"2016\":\"2016\",\"2017\":\"2017\",\"2018\":\"2018\"}}}},\"id\":[\"unit\",\"nace_r2\",\"age\",\"geo\",\"time\"],\"size\":[1,2,2,2,4]}";
        private string json2 = "{\"version\":\"2.0\",\"label\":\"Non-fatal accidents at work by NACE Rev. 2 activity and age\",\"href\":\"http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/hsw_n2_03?precision=1&geo=AT&geo=BE&unit=RT_INC&time=2015&time=2016&time=2017&time=2018&age=TOTAL&nace_r2=A&nace_r2=B\",\"source\":\"Eurostat\",\"updated\":\"2020-08-18\",\"extension\":{\"datasetId\":\"hsw_n2_03\",\"lang\":\"EN\",\"description\":null,\"subTitle\":null},\"class\":\"dataset\",\"value\":{\"0\":2099.4,\"1\":4846.39,\"2\":5324.84,\"3\":2770.94,\"4\":625.57,\"5\":1786.03,\"6\":1765.78,\"7\":1668.13,\"8\":2221.57,\"9\":1678.7,\"10\":2479.12,\"11\":2579.59,\"12\":2225.37,\"13\":3725.66,\"14\":3480.08,\"15\":3212.52},\"dimension\":{\"unit\":{\"label\":\"unit\",\"category\":{\"index\":{\"RT_INC\":0},\"label\":{\"RT_INC\":\"Incidence rate\"}}},\"nace_r2\":{\"label\":\"nace_r2\",\"category\":{\"index\":{\"A\":0,\"B\":1},\"label\":{\"A\":\"Agriculture, forestry and fishing\",\"B\":\"Mining and quarrying\"}}},\"age\":{\"label\":\"age\",\"category\":{\"index\":{\"TOTAL\":0},\"label\":{\"TOTAL\":\"Total\"}}},\"geo\":{\"label\":\"geo\",\"category\":{\"index\":{\"AT\":0,\"BE\":1},\"label\":{\"AT\":\"Austria\",\"BE\":\"Belgium\"}}},\"time\":{\"label\":\"time\",\"category\":{\"index\":{\"2015\":0,\"2016\":1,\"2017\":2,\"2018\":3},\"label\":{\"2015\":\"2015\",\"2016\":\"2016\",\"2017\":\"2017\",\"2018\":\"2018\"}}}},\"id\":[\"unit\",\"age\",\"geo\",\"time\",\"nace_r2\"],\"size\":[1,1,2,4,2]}";
        private string values1 = "{\"0\":2099.4,\"1\":4846.39,\"2\":5324.84,\"3\":2770.94,\"4\":625.57,\"5\":1786.03,\"6\":1765.78,\"7\":1668.13,\"8\":1125.35,\"9\":1174,\"10\":1339.59,\"11\":2262.16,\"12\":1390.07,\"13\":0,\"14\":3660.34,\"15\":0,\"16\":2221.57,\"17\":1678.7,\"18\":2479.12,\"19\":2579.59,\"20\":2225.37,\"21\":3725.66,\"22\":3480.08,\"23\":3212.52,\"24\":0,\"25\":0,\"26\":1629.73,\"27\":0,\"28\":0,\"29\":0,\"30\":0,\"31\":0}";
        private string values2 = "{\"0\":2099.4,\"1\":4846.39,\"2\":5324.84,\"3\":2770.94,\"4\":625.57,\"5\":1786.03,\"6\":1765.78,\"7\":1668.13,\"8\":2221.57,\"9\":1678.7,\"10\":2479.12,\"11\":2579.59,\"12\":2225.37,\"13\":3725.66,\"14\":3480.08,\"15\":3212.52}";
        private string id1 = "[\"unit\",\"nace_r2\",\"age\",\"geo\",\"time\"]";
        private string id2 = "[\"unit\",\"age\",\"geo\",\"time\",\"nace_r2\"]";
        private string size1 = "[1,2,2,2,4]";
        private string size2 = "[1,1,2,4,2]";
        private List<String> idList1 = new List<String>{"unit","nace_r2","age","geo","time"};
        private List<String> idList2 = new List<String>{"unit","age","geo","time","nace_r2"};
        private List<int> indexes1 = new List<int>{0, 1, 3};
        private List<int> indexes2_1 = new List<int>{1, 1, 1};
        private List<int> indexes2_2 = new List<int>{0, 0, 0};
        private String nace1 = "A";
        private String nace2_1 = "B";
        private String nace2_2 = "A";
        private String region1 = "BE";
        private String region2_1 = "BE";
        private String region2_2 = "AT";
        private int year1 = 2018;
        private int year2_1 = 2016;
        private int year2_2 = 2015;
        private List<String> subids1;
        private List<String> subids2;
        private List<int> subsize1;
        private List<int> subsize2;
        
        
        [TestInitialize()]
        public void Setup()
        {
            subids1 = new List<string>(){"nace_r2","geo","time"};
            subids2 = new List<string>(){"geo","time","nace_r2"};   

            subsize1 = new List<int>(){2, 2, 4};
            subsize2 = new List<int>(){2, 4, 2};

            jun1 = new EuroStatJSONUnNester(json1);
            jun2 = new EuroStatJSONUnNester(json2);
        }

        [TestMethod()]
        public void GetSizeShouldReturnExpectedList(){
            List<int> sizeFromMethod1 = jun1.GetSize();
            string listAsString = "[" + string.Join(",", sizeFromMethod1) + "]";
            Assert.AreEqual(size1, listAsString);
            List<int> sizeFromMethod2 = jun2.GetSize();
            string listAsString2 = "[" + string.Join(",", sizeFromMethod2) + "]";
            Assert.AreEqual(size2, listAsString2);
        }
        
        public void GetIdShouldReturnExpectedList(){
            List<String> idFromMethod1 = jun1.GetID();
            string listAsString = "[" +string.Join(",", idFromMethod1 + "]");
            Assert.AreEqual(id1, listAsString);
            List<String> idFromMethod2 = jun2.GetID();
            string listAsString2 = "[" + string.Join(",", idFromMethod2) + "]";
            Assert.AreEqual(id2, listAsString2);
        }

        [TestMethod()]
        public void GetValueShouldReturnExpectedList(){
            Dictionary<String, String> valueDict1 = jun1.GetValues();
            string valuesString1 = "{";
            foreach (KeyValuePair<String, String> entry in valueDict1)
            {
                valuesString1 = valuesString1 + "\"" + entry.Key + "\":" + entry.Value + ",";
            }
            valuesString1 = valuesString1.Remove(valuesString1.Length - 1, 1) + "}";
            Assert.AreEqual(values1, valuesString1);

            Dictionary<String, String> valueDict2 = jun2.GetValues();
            string valuesString2 = "{";
            foreach (KeyValuePair<String, String> entry in valueDict2)
            {
                valuesString2 = valuesString2 + "\"" + entry.Key + "\":" + entry.Value + ",";
            }
            valuesString2 = valuesString2.Remove(valuesString2.Length - 1, 1) + "}";
            Assert.AreEqual(values2, valuesString2);
        }

        [TestMethod()]
        public void GetNestedFieldWithNaceShouldReturnNaceDict(){
            Dictionary<int, String> naceDict = jun1.GetNestedField("nace_r2");
            Dictionary<int, String> expectedDict = new Dictionary<int, string>(){
                {0, "A"},
                {1, "B"}
            };
            CollectionAssert.AreEqual(expectedDict, naceDict);
        }

        [TestMethod()]
        public void GetNestedFieldWithGeoShouldReturnRegionDict(){
            Dictionary<int, String> regionDict = jun1.GetNestedField("geo");
            Dictionary<int, String> expectedDict = new Dictionary<int, string>(){
                {0, "AT"},
                {1, "BE"}
            };
            CollectionAssert.AreEqual(expectedDict, regionDict);
        }

        [TestMethod()]
        public void GetNestedFieldWithTimeShouldReturnYearDict(){
            Dictionary<int, String> yearDict = jun1.GetNestedField("time");
            Dictionary<int, String> expectedDict = new Dictionary<int, string>(){
                {0, "2015"},
                {1, "2016"},
                {2, "2017"},
                {3, "2018"}
            };
            CollectionAssert.AreEqual(expectedDict, yearDict);
        }

        [TestMethod()]
        [DataRow(0,"A")]
        [DataRow(1,"B")]
        public void GetNaceShouldFindCorrectNaceForJsonUnNester(int naceId, string expected){
            Assert.AreEqual(expected, jun1.GetNaceCode(naceId));
        }

        [TestMethod()]
        [DataRow(0,"AT")]
        [DataRow(1,"BE")]
        public void GetNaceShouldFindCorrectRegionForJsonUnNester2(int regionId, string expected){
            Assert.AreEqual(expected, jun1.GetRegionCode(regionId));
        }

        [TestMethod()]
        [DataRow(0,2015)]
        [DataRow(1,2016)]
        [DataRow(2,2017)]
        [DataRow(3,2018)]
        public void GetNaceShouldFindCorrectYearForJsonUnNester2(int yearId, int expected){
            Assert.AreEqual(expected, jun1.GetYear(yearId));
        }
    }
}