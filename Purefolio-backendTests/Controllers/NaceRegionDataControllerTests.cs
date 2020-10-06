using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Purefolio_backend.Controllers;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Purefolio_backend.Controllers.Tests
{
    [TestClass()]
    public class NaceRegionDataControllerTests
    {
        public NaceRegionDataController naceController;
        public MockData mockData;

        [TestMethod()]
        public void NaceControllerTest()
        {
        }

        [TestMethod()]
        public void GetTest()
        {
            var mockDataLogger = new Mock<ILogger<MockData>>();
            var mockData = new MockData(mockDataLogger.Object);
            var mockLogger = new Mock<ILogger<NaceRegionDataController>>();
            var mockDatabaseStore = new Mock<IDatabaseStore>();

            int naceId = 1;
            int regionId = 2;
            int year = 2018;

            NaceRegionData nrd = new NaceRegionData(){naceId = naceId, regionId = regionId, year = year, emissionPerYear = 20};
            List<NaceRegionData> nrdList = new List<NaceRegionData>() { nrd };
            mockDatabaseStore.Setup(ds => ds.getNaceRegionData(naceId, regionId, year))
                .Returns(nrdList);
            this.naceController = new NaceRegionDataController(mockLogger.Object, mockDatabaseStore.Object);

            Assert.AreEqual(naceController.Get(naceId, regionId, year), nrdList);
        }
    }
}