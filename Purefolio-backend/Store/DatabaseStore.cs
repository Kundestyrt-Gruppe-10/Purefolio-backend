using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;

namespace Purefolio_backend
{
  public interface IDatabaseStore
    {
        // TODO: Add all methods to this interface for easy mocking
        public Nace createNace(Nace nace);
    }
  public class DatabaseStore: IDatabaseStore
  {
    // TODO: When project grows, split this up into multiple classes
    private DatabaseContext db;

    private readonly ILogger<DatabaseStore> _logger;

    public DatabaseStore(ILogger<DatabaseStore> _logger)
    {
      this.db = new DatabaseContext();
      this._logger = _logger;
    }

    public Nace AddOrUpdateNace(Nace nace)
    {
      _logger.LogInformation($"AdOrUpdateNace {nace}");
      db.Nace.Add (nace);
      db.SaveChanges();
      return nace;
    }

    public List<Nace> getAllNace()
    {
      return db.Nace.ToList();
    }

    public Region getRegionById(int regionId)
        {
            return db.Region
                .Where(row =>
                    row.regionId == regionId
                ).Single();
        }

    public Nace getNaceById(int naceId)
        {
            return db.Nace
                .Where(row =>
                    row.naceId == naceId
                ).Single();
        }
    public NaceRegionData
    getNaceRegionDataByNaceRegionId(string regionCode, string naceCode)
    {
      return db
        .NaceRegionData
        .Where(row =>
          row.nace.naceCode == naceCode && row.region.regionCode == regionCode)
        .Single();
    }
    public Nace createNace(Nace nace)
    {
            db.Nace.Add(nace);
            db.SaveChanges();
            return nace;
    }
    public NaceRegionData createNaceRegionData(NaceRegionData naceRegionData)
        {
            db.NaceRegionData.Add(naceRegionData);
            db.SaveChanges();
            return naceRegionData;
        }
    public Region createRegion(Region region)
    {
            db.Region.Add(region);
            db.SaveChanges();
            return region;
    }
    public RegionData createRegionData(RegionData regionData)
    {
            db.RegionData.Add(regionData);
            db.SaveChanges();
            return regionData;
    }
  }
}
