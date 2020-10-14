﻿using Microsoft.Extensions.DependencyInjection;
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
    public class NaceControllerTests : ControllerIntegrationTestBase
    {
        private NaceController naceController;

        public NaceControllerTests() : base()
        {
            var controllerLogger = new Mock<ILogger<NaceController>>();
            naceController = new NaceController(controllerLogger.Object, this._databaseStore);
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.IsTrue(this._databaseStore.getAllNaces().SequenceEqual(naceController.Get()));
        }
    }
}