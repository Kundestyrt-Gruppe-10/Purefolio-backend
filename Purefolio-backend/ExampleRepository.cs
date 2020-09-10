using Microsoft.AspNetCore.Components.Forms;
using Purefolio.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purefolio_backend
{
    public class ExampleRepository
    {
        private DatabaseContext databaseContext;
        public ExampleRepository()
        {
            this.databaseContext = new DatabaseContext();
        }

    }
}
