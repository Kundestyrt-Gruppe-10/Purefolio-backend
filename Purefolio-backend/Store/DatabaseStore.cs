﻿using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Purefolio_backend
{
    public interface IDatabaseStore
    {
        public List<Nace> getAllNaces();
        public List<NaceWithHasData> getAllNacesWithHasData(int regionId, int tableId);
        public List<RegionWithHasData> getAllRegionsWithHasData(int naceId, int tableId);
        public List<NaceRegionData> getNaceRegionData(int? regionId, int? naceId, int? fromYear, int? toYear);
        public List<Region> getAllRegions();
        public Nace getNaceById(int id);
        public Region getRegionById(int id);
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
        public Nace getNaceById(int id){
            return db.Nace.Find(id);
        }
        public Region getRegionById(int id)
        {
            return db.Region.Find(id);
        }
        public List<Nace> getAllNaces()
        {
            return db.Nace.ToList();
        }

        public List<RegionWithHasData> getAllRegionsWithHasData(int naceId, int tableId)
        {
            string tableName = db.EuroStatTable.First( table => table.tableId == tableId).attributeName;
            System.Reflection.PropertyInfo prop = typeof(NaceRegionData).GetProperty(tableName);
            
            return db.Region.ToList().Select(region => new RegionWithHasData 
            {
                regionId = region.regionId,
                regionName = region.regionName,
                regionCode = region.regionCode,
                area = region.area,
                hasData = db.NaceRegionData.Where( nrd => nrd.regionId == region.regionId && nrd.naceId == naceId)
                .ToList()
                .Find(nrd => prop.GetValue(nrd) != null) != null
            }
            ).ToList();
        }

        public List<NaceWithHasData> getAllNacesWithHasData(int regionId, int tableId)
        {
            string tableName = db.EuroStatTable.First( table => table.tableId == tableId).attributeName;
            System.Reflection.PropertyInfo prop = typeof(NaceRegionData).GetProperty(tableName);
            
            return db.Nace.ToList().Select(nace => new NaceWithHasData 
            {
                naceId = nace.naceId,
                naceName = nace.naceName,
                naceCode = nace.naceCode,
                hasData = db.NaceRegionData.Where( nrd => nrd.naceId == nace.naceId && nrd.regionId == regionId)
                .ToList()
                .Find(nrd => prop.GetValue(nrd) != null) != null
            }
            ).ToList();
        }


        public List<Region> getAllRegions()
        {
            return db.Region.ToList();
        }

        public List<NaceRegionData> getAllNaceRegionData()
        {
            return db.NaceRegionData.ToList();
        }

        public List<NaceRegionData> getNaceRegionData(int? regionId, int? naceId, int? fromYear, int? toYear)
        {
            return db.NaceRegionData.Where(row => 
                (regionId == null || row.regionId == regionId) &&
                (naceId == null || row.naceId == naceId) &&
                (fromYear == null || row.year >= fromYear) && 
                (toYear == null || row.year <= toYear))
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
