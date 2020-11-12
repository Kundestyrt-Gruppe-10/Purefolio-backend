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
using System.Threading.Tasks;


namespace Purefolio_backend.Controllers.Tests
{
    [TestClass()]
    public class EuroStatTableControllerTests : ControllerIntegrationTestBase
    {
        public EuroStatTableController euroStatTableController;
        public EuroStatTableControllerTests() : base()
        {
            var controllerLogger = new Mock<ILogger<EuroStatTableController>>();
            euroStatTableController = new EuroStatTableController(controllerLogger.Object, this._databaseStore);
        }

        [TestMethod()]
        public async Task GetESGFactorTest()
        {
            List<EuroStatTable> tables = await this._databaseStore.getAllEuroStatTables();
            List<String> expected = tables.ConvertAll(table => table.attributeName);
            Assert.IsTrue(expected.SequenceEqual(await euroStatTableController.getESGFactors()));
        }

        [TestMethod()]
        public async Task GetAllTablesTest()
        {
            List<EuroStatTable> expected = await this._databaseStore.getAllEuroStatTables();
            Assert.IsTrue(expected.SequenceEqual(await euroStatTableController.getAllTables()));
        }
    }
}