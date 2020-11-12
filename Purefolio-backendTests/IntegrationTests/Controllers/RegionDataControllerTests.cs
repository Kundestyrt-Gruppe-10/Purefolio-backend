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
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Purefolio_backend.Controllers.Tests
{
    [TestClass()]
    public class RegionDataControllerTests : ControllerIntegrationTestBase
    {
        private RegionDataController regionDataController;

        public RegionDataControllerTests() : base()
        {
            var controllerLogger = new Mock<ILogger<RegionDataController>>();
            regionDataController = new RegionDataController(controllerLogger.Object, this._databaseStore);
        }

        [TestMethod()]
        public async Task GetAllTest()
        {
            IEnumerable<RegionData> response = await regionDataController.GetAllRegionData();
            List<RegionData> regions = await this._databaseStore.getAllRegionData();
            Assert.IsTrue(regions.SequenceEqual(response));
        }

    }
}