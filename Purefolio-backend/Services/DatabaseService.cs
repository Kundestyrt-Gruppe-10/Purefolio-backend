using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purefolio_backend
{
    public class DatabaseService

    {
        private DatabaseContext db;
        private readonly ILogger<DatabaseService> _logger;
        public DatabaseService(ILogger<DatabaseService> _logger)
        {
            this.db = new DatabaseContext();
            this._logger = _logger;
        }

        public Nace AddOrUpdateNace(Nace nace)
        {
            _logger.LogInformation($"AdOrUpdateNace {nace}");
            db.Nace.Add(nace);
            db.SaveChanges();
            return nace;

        }
        public List<Nace> getAllNace()
        {
            return db.Nace.ToList();

        }

        public NaceRegionData getNaceRegionDataByNaceRegionId(string regionCode, string naceCode)
        {
            return db.NaceRegionData
                .Where(row => 
                row.Nace.NaceCode == naceCode && 
                row.Region.RegionCode == regionCode)
                .Single();

        }
    }
}
