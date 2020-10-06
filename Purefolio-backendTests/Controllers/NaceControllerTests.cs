﻿using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Purefolio_backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Purefolio_backend.Controllers.Tests
{
    [TestClass()]
    public class NaceControllerTests
    {
        public NaceController naceController;
        public MockData mockData;

        [TestMethod()]
        public void NaceControllerTest()
        {
        }

        [TestMethod()]
        public void GetTest()
        {
          // TODO: Fix test.
            var mockDataLogger = new Mock<ILogger<MockData>>();
            var mockData = new MockData(mockDataLogger.Object);
            var mockLogger = new Mock<ILogger<NaceController>>();
            var mockDatabaseStore =  new Mock<IDatabaseStore>();
            var nace = new Nace() { naceId = 0, naceCode = "A", naceName = "Agriculture, forestry and fishing" };
            mockDatabaseStore.Setup(ds => ds.getAllNace())
                .Returns(new List<Nace>() { nace });
            this.naceController = new NaceController(mockLogger.Object, mockDatabaseStore.Object);
            
            Assert.AreEqual(naceController.Get().First(),  nace
            
            );
        }
    }
}