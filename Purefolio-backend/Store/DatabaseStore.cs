﻿using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Purefolio_backend
{
    public interface IDatabaseStore
    {
        public List<Nace> getAllNaces();
        public List<NaceRegionData> getNaceRegionData(int? regionId, int? naceId, int? year);
        public List<Region> getAllRegions();
        public List<RegionData> getAllRegionData();
        public List<EuroStatTable> getAllEuroStatTables();
        public List<NaceRegionData> getAllNaceRegionData();
        public List<NaceRegionData> addNaceRegionData(List<NaceRegionData> newNaceRegionData);
        public Region createRegion(Region region);
        public Nace createNace(Nace nace);
        public EuroStatTable createEuroStatTable(EuroStatTable table);

    }
    public class DatabaseStore : IDatabaseStore
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
        public List<Nace> getAllNaces()
        {
            return db.Nace.ToList();
        }

        public List<Region> getAllRegions()
        {
            return db.Region.ToList();
        }

        public List<NaceRegionData> getAllNaceRegionData()
        {
            return db.NaceRegionData.ToList();
        }

        public List<NaceRegionData> getNaceRegionData(int? regionId, int? naceId, int? year)
        {
            return db.NaceRegionData.Where(row => 
                (regionId == null || row.regionId == regionId) &&
                (naceId == null || row.naceId == naceId) &&
                (year == null || row.year == year))
                .OrderBy(nrd => nrd.year)
                .ToList();
        }

        public List<RegionData> getAllRegionData()
        {
            return db.RegionData.ToList();
        }

        public List<EuroStatTable> getAllEuroStatTables()
        {
            return db.EuroStatTable.ToList();
        }

        public Nace createNace(Nace nace)
        {
            db.Nace.Add(nace);
            db.SaveChanges();
            return nace;
        }

        public EuroStatTable createEuroStatTable(EuroStatTable table)
        {
            db.EuroStatTable.Add(table);
            db.SaveChanges();
            return table;
        }
        public Region createRegion(Region region)
        {
            db.Region.Add(region);
            db.SaveChanges();
            return region;
        }

        public List<RegionData> addRegionData(List<RegionData> newRegionData)
        {
            List<RegionData> existingRegionData = db.RegionData.ToList();
            foreach (RegionData newRD in newRegionData)
            {
                RegionData existingElement = existingRegionData.Find((exRD) => exRD.Equals(newRD));
                if (existingElement == null)
                {
                    db.RegionData.Add(newRD);
                }
                else
                {
                    existingElement.merge(newRD);
                }
            }
            db.SaveChanges();
            return db.RegionData.ToList();
        }

        public List<NaceRegionData> addNaceRegionData(List<NaceRegionData> newNaceRegionData)
        {
            List<NaceRegionData> existingNaceRegionData = db.NaceRegionData.ToList();
            foreach (NaceRegionData newNRD in newNaceRegionData)
            {
                NaceRegionData existingElement = existingNaceRegionData.Find((exNRD) => exNRD.Equals(newNRD));
                if (existingElement == null)
                {
                    db.NaceRegionData.Add(newNRD);
                }
                else
                {
                    existingElement.merge(newNRD);
                }
            }
            db.SaveChanges();
            return db.NaceRegionData.ToList();
        }
    }
}
