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
    public class NaceRegionDataControllerTests : ControllerIntegrationTestBase
    {
        public NaceRegionDataController naceRegionDataController;
        public NaceRegionDataControllerTests() : base()
        {
            var controllerLogger = new Mock<ILogger<NaceRegionDataController>>();
            naceRegionDataController = new NaceRegionDataController(controllerLogger.Object, this._databaseStore);
        }

        [TestMethod()]
        [DataRow(1,15,2018)]
        [DataRow(1,15,2019)]
        public async void GetTest(int naceId, int regionId, int year)
        {            
            List<NaceRegionData> nrd = await this._databaseStore.getNaceRegionData(naceId, regionId, year);
            Assert.IsTrue(nrd.SequenceEqual(await naceRegionDataController.Get(naceId, regionId, year)));
        }
    }
}