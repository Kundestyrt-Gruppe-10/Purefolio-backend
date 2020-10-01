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
    public class NaceControllerTests
    {
        public NaceController naceController;
        public MockData mockData;
        private Mock<ILogger<MockData>> _mockLogger;
        private Mock<ILogger<NaceController>> _naceControllerLogger;
        private Mock<IDatabaseStore> mockDs;

        [TestMethod()]
        public void NaceControllerTest()
        {
            _mockLogger = new Mock<ILogger<MockData>>();
            _naceControllerLogger = new Mock<ILogger<NaceController>>();
            mockData = new MockData(_mockLogger.Object);

        }

        [TestMethod()]
        public void GetTest()
        {
        }

        [TestMethod()]
        public void CreateNaceTest()
        {
            Nace nace = new Nace
            {
                naceCode = "A",
                naceName = "Culture and shit"
            };
            mockDs = new Mock<IDatabaseStore>();
            mockDs.Setup(ds => ds.createNace(nace))
                .Returns(nace);
            this.naceController = new NaceController(
                    _naceControllerLogger.Object,
                    mockData,
                    mockDs.Object
                );
            Nace returnedNace = naceController.CreateNace(nace);
            Assert.AreEqual(nace, returnedNace);
        }
    }
}