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
    public class ControllerIntegrationTestBase : IntegrationTestBase
    {
        protected DatabaseStore _databaseStore;
        
        public ControllerIntegrationTestBase() : base()
        {
            var databaseStoreLogger = new Mock<ILogger<DatabaseStore>>();
            _databaseStore = new DatabaseStore(databaseStoreLogger.Object, this._context, this._context_wp);
        }
        
    }
}