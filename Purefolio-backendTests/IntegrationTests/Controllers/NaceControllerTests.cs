﻿using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Purefolio_backend.Controllers.Tests
{
    [TestClass()]
    public class NaceControllerTests : ControllerIntegrationTestBase
    {
        private NaceController naceController;

        public NaceControllerTests() : base()
        {
            var controllerLogger = new Mock<ILogger<NaceController>>();
            naceController = new NaceController(controllerLogger.Object, this._databaseStore);
        }

        [TestMethod()]
        public async Task GetAllNacesTest()
        {
            ActionResult<IEnumerable<Nace>> response = await naceController.GetAll();
            List<Nace> naces = await this._databaseStore.getAllNaces();
            Assert.IsTrue(naces.SequenceEqual(response.Value));
        }

        [TestMethod()]
        [DataRow(1, 1)]
        [DataRow(1, 4)]
        public async Task GetWithHasDataTest(int regionId, int tableId)
        {
            ActionResult<IEnumerable<NaceWithHasData>> response = await naceController.GetWithHasData(regionId, tableId);
            List<NaceWithHasData> naces = await this._databaseStore.getAllNacesWithHasData(regionId, tableId);
            Assert.IsTrue(naces.SequenceEqual(response.Value));
        }
    }
}