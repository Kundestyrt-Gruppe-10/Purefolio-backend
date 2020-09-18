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
        [TestMethod()]
        public void NaceControllerTest()
        {
        }

        [TestMethod()]
        public void GetTest()
        {
            var mockLogger = new Mock<ILogger<NaceController>>();
            this.naceController = new NaceController(mockLogger.Object);
            
            Assert.AreEqual(naceController.Get().First(), 
            new Nace() { NaceId = 0, NaceCode = "A", NaceName = "Agriculture, forestry and fishing" }
            );
        }
    }
}