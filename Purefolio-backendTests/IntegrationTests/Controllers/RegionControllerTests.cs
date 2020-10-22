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
        public void GetTest()
        {
            ActionResult<IEnumerable<Region>> response = regionController.GetAll();
            Assert.IsTrue(this._databaseStore.getAllRegions().SequenceEqual(response.Value));
        }
    }
}