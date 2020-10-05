using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;

namespace Purefolio_backend
{
  public class DatabaseStore
  {
    // TODO: When project grows, split this up into multiple classes
    private DatabaseContext db;

    private readonly ILogger<DatabaseStore> _logger;

    public DatabaseStore(ILogger<DatabaseStore> _logger, DatabaseContext db)
    {
      // this.db = new DatabaseContext();
      this.db = db;
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

    public List<RegionData> addRegionData(List<RegionData> newRegionData)
    {
      List<RegionData> existingRegionData = db.RegionData.ToList();
      foreach (RegionData newRD in newRegionData)
      {
          RegionData existingElement = existingRegionData.Find((exRD)=> exRD.Equals(newRD));
          if (existingElement == null)
          {
              createRegionData(newRD);
          }
          else
          {
              existingElement.merge(newRD);
              db.SaveChanges();
          }
      }
      return db.RegionData.ToList();
    }

    public List<NaceRegionData> addNaceRegionData(List<NaceRegionData> newNaceRegionData)
    {
      List<NaceRegionData> existingNaceRegionData = db.NaceRegionData.ToList();
      foreach (NaceRegionData newNRD in newNaceRegionData)
      {
          NaceRegionData existingElement = existingNaceRegionData.Find((exNRD)=> exNRD.Equals(newNRD));
          if (existingElement == null)
          {
              createNaceRegionData(newNRD);
          }
          else
          {
              existingElement.merge(newNRD);
              db.SaveChanges();
          }
      }
      return db.NaceRegionData.ToList();
    }

  }
}
