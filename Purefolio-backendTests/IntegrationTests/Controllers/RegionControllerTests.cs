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
        public async void GetTest()
        {
            ActionResult<IEnumerable<Region>> response = await regionController.GetAll();
            List<Region> regions = await this._databaseStore.getAllRegions();
            Assert.IsTrue(regions.SequenceEqual(response.Value));
        }
    }
}