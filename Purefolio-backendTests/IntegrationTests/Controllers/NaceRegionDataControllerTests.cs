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
        [DataRow()]
        [DataRow(1,15)]
        [DataRow(1,15,2017, 2018)]
        public void GetTest(int? naceId=null, int? regionId=null, int? fromYear=null, int? toYear=null)
        {            
            Assert.IsTrue(this._databaseStore.getNaceRegionData(naceId, regionId, fromYear, toYear).SequenceEqual(naceRegionDataController.Get(naceId, regionId, fromYear, toYear)));
        }
    }
}