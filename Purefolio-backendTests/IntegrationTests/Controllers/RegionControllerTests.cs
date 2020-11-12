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
    public class RegionControllerTests : ControllerIntegrationTestBase
    {
        private RegionController regionController;

        public RegionControllerTests() : base()
        {
            var controllerLogger = new Mock<ILogger<RegionController>>();
            regionController = new RegionController(controllerLogger.Object, this._databaseStore);
        }

        [TestMethod()]
        public async Task GetAllTest()
        {
            ActionResult<IEnumerable<Region>> response = await regionController.GetAll();
            List<Region> regions = await this._databaseStore.getAllRegions();
            Assert.IsTrue(regions.SequenceEqual(response.Value));
        }

        [TestMethod()]
        [DataRow(1, 1)]
        [DataRow(1, 4)]
        public async Task GetWithHasDataTest(int naceId, int tableId)
        {
            ActionResult<IEnumerable<RegionWithHasData>> response = await regionController.GetWithHasData(naceId, tableId);
            List<RegionWithHasData> regions = await this._databaseStore.getAllRegionsWithHasData(naceId, tableId);
            Assert.IsTrue(regions.SequenceEqual(response.Value));
        }
    }
}