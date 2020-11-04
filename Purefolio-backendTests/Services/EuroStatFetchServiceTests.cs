using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net.Http;
using Newtonsoft.Json;
using Purefolio_backend.Models;
using Purefolio_backend.Services;

namespace Purefolio_backend.Models.Tests
{
    [TestClass()]
    public class EuroStatFetchServiceTests
    {
        private EuroStatFetchService euroStatFetchService;
        private EuroStatJSONToObjectsConverterService jsc;
        private Nace a = new Nace() {  naceCode = "A", naceName = "Agriculture, forestry and fishing" };
        private Nace b = new Nace() {  naceCode = "B", naceName = "Mining and quarrying" };
        private Nace t97 = new Nace() { naceCode = "T97", naceName = ""};
        private List<Nace> naceFilter1 = new List<Nace>();
        private List<Nace> naceFilter2 = new List<Nace>();
        private String eurostatApiEndpoint;
        private String StaticFilters;
        private int StartYear;
        private int EndYear;
        private Mock<ILogger<EuroStatFetchService>> mockLogger;
        private Mock<ILogger<JsonConverter>> mockJSONLogger;
        private Mock<IDatabaseStore> mockDBS;
        private Mock<IHttpClientFactory> mockFactory;

        [TestInitialize()]
        public void Setup()
        {
            mockDBS = new Mock<IDatabaseStore>();
            mockJSONLogger = new Mock<ILogger<JsonConverter>>();
            jsc = new EuroStatJSONToObjectsConverterService(mockJSONLogger.Object, mockDBS.Object);
            mockFactory = new Mock<IHttpClientFactory>();
            mockLogger = new Mock<ILogger<EuroStatFetchService>>();

            euroStatFetchService = new EuroStatFetchService(mockLogger.Object, mockFactory.Object, mockDBS.Object, jsc);
            EuroStatTable eu1 = new EuroStatTable(){tableCode = "env_ac_ainah_r2", attributeName = "emissionPerYear", dataType="NaceRegionData", unit="unit=KG_HAB&airpol=GHG"};
            EuroStatTable eu2 = new EuroStatTable(){tableCode = "hsw_n2_03", attributeName = "workAccidentsIncidentRate", dataType="NaceRegionData", unit="unit=RT_INC&age=TOTAL"};
            EuroStatTable eu3 = new EuroStatTable(){tableCode = "earn_gr_gpgr2", attributeName = "genderPayGap", dataType="NaceRegionData", unit="unit=PC"};
            EuroStatTable eu4 = new EuroStatTable(){tableCode = "env_ac_taxind2", attributeName = "environmentTaxes", dataType="NaceRegionData", unit="tax=ENV&unit=MIO_EUR"};
            EuroStatTable eu5 = new EuroStatTable(){tableCode = "hsw_n2_02", attributeName = "fatalAccidentsAtWork", dataType="NaceRegionData", unit="unit=RT_INC"};
            EuroStatTable eu6 = new EuroStatTable(){tableCode = "lfsa_etgan2", attributeName = "temporaryemployment", dataType="NaceRegionData", unit="sex=T&unit=THS&age=Y15-74"};
            EuroStatTable eu7 = new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesPrimaryEducation", dataType="NaceRegionData", unit="sex=T&unit=PC&isced11=ED0-2&age=Y15-74"};
            EuroStatTable eu8 = new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesSecondaryEducation", dataType="NaceRegionData", unit="sex=T&unit=PC&isced11=ED3_4&age=Y15-74"};
            EuroStatTable eu9 = new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesTertiaryEducation", dataType="NaceRegionData", unit="sex=T&unit=PC&isced11=ED5-8&age=Y15-74"};
            List<EuroStatTable> listEuro = new List<EuroStatTable>();

            listEuro.Add(eu1);
            listEuro.Add(eu2);
            listEuro.Add(eu3);
            listEuro.Add(eu4);
            listEuro.Add(eu5);
            listEuro.Add(eu6);
            listEuro.Add(eu7);
            listEuro.Add(eu8);
            listEuro.Add(eu9);

            mockDBS.Setup(x => x.getAllNaceRegionData()).Returns(new List<NaceRegionData>());
            mockDBS.Setup(x => x.addNaceRegionData(new List<NaceRegionData>())).Returns(new List<NaceRegionData>());
            mockDBS.Setup(x => x.getAllEuroStatTables()).Returns(listEuro);
            eurostatApiEndpoint = euroStatFetchService.GetEuroStatAPIEndpoint();
            StaticFilters = euroStatFetchService.GetStaticFilters();
            StartYear = euroStatFetchService.GetStartYear();
            EndYear = euroStatFetchService.GetEndYear();

        }

        [TestMethod()]
        [DataRow("earn_gr_gpgr2", 0 ,2015 , 2018, "http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/earn_gr_gpgr2?precision=1&nace_r2=A&nace_r2=B&nace_r2=T97&time=2015&time=2016&time=2017&time=2018&")]
        [DataRow("earn_gr_gpgr2", 0 ,2018 , 2015, "http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/earn_gr_gpgr2?precision=1&nace_r2=A&nace_r2=B&nace_r2=T97&")]
        public void GetEurostatURLShouldGiveCorrectURL(string tableCode, int index, int start, int end, string expectedUrl)
        {
            naceFilter2.Add(a);
            naceFilter2.Add(b);
            naceFilter2.Add(t97);
            EuroStatTable test_table = null;
            List<EuroStatTable> tables = mockDBS.Object.getAllEuroStatTables();
            foreach (EuroStatTable table in tables)
            {
                if(table.tableCode == tableCode) {
                    test_table = table;
                }
            }
            string actualUrl = euroStatFetchService.GetEuroStatURL(test_table, index, naceFilter2, start, end);
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod()]
        [DataRow(249)]
        [DataRow(0)]
        [DataRow(50)]
        [DataRow(51)]
        [DataRow(-1)]
        [DataRow(-145)]
        public void GetFetchIterationsCountShouldGiveCorrectIterationCount(int NacefilterLength)
        {

            for (int i = 0; i < NacefilterLength; i++)
            {
                naceFilter2.Add(a);
            }
            int actualIterations = euroStatFetchService.GetFetchIterationsCount(naceFilter2);
            int expectedIterations = 0;
            int MaxElementsFromFetch = euroStatFetchService.GetMaxElementsFromFetch();
            while (NacefilterLength > 0) 
            {
                NacefilterLength = NacefilterLength - MaxElementsFromFetch;
                expectedIterations++;
            }
            Assert.AreEqual(expectedIterations, actualIterations);
        }

        [TestMethod()]
        [DataRow("&nace_r2=H49&nace_r2=H50&nace_r2=H51&nace_r2=H52&nace_r2=H53&nace_r2=I&nace_r2=I55", "H49", "H50", "H51", "H52", "H53", "I", "I55")]
        [DataRow(null)]
        [DataRow("&nace_r2=H49", "H49")]
        public void GetNaceFiltersShouldGiveCorrectNaceFilters(string expectedNaceFilters, params string[] naces)
        {
            foreach (string naceString in naces)
            {
                Nace nace = new Nace() {naceCode = naceString};
                naceFilter1.Add(nace);
            }

            string actualNaceFilters = euroStatFetchService.GetNaceFilters(0, naceFilter1);
            Assert.AreEqual(expectedNaceFilters, actualNaceFilters);
        }

        [TestMethod()]
        [DataRow(2015, 2018, "&time=2015&time=2016&time=2017&time=2018")]
        [DataRow(2018, 2018, "&time=2018")]
        [DataRow(2018, 2015, null)]
        public void GetTimeFiltersShouldGiveCorrectTimeFilters(int start, int end, string expectedTimeFilters)
        {
            string actualTimeFilters = euroStatFetchService.GetTimeFilters(start, end);
            Assert.AreEqual(expectedTimeFilters, actualTimeFilters);
        }
    }
}
