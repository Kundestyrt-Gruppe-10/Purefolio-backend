﻿using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Purefolio_backend
{
    public interface IDatabaseStore
    {
        public Task<List<Nace>> getAllNaces();
        public Task<List<NaceWithHasData>> getAllNacesWithHasData(int regionId, int tableId);
        public Task<List<RegionWithHasData>> getAllRegionsWithHasData(int naceId, int tableId);
        public Task<List<NaceRegionData>> getNaceRegionData(int? regionId, int? naceId, int? fromYear, int? toYear);
        public Task<List<Region>> getAllRegions();
        public Task<Nace> getNaceById(int id);
        public Task<Region> getRegionById(int id);
        public Task<List<RegionData>> getAllRegionData();
        public Task<List<EuroStatTable>> getAllEuroStatTables();
        public Task<List<NaceRegionData>> getAllNaceRegionData();
        public Task<List<NaceRegionData>> addNaceRegionData(List<NaceRegionData> newNaceRegionData);
        public Task<List<int>> getYearsWithData();
        public Task<Region> createRegion(Region region);
        public Task<Nace> createNace(Nace nace);
        public Task<EuroStatTable> createEuroStatTable(EuroStatTable table);
    }
    public class DatabaseStore : IDatabaseStore
    {
        // TODO: When project grows, split this up into multiple classes
        private DatabaseContext db;

        private DatabaseContextWithProxy db_wp;

        private readonly ILogger<DatabaseStore> _logger;

        public DatabaseStore(ILogger<DatabaseStore> _logger, DatabaseContext db, DatabaseContextWithProxy db_wp)
        {
            // this.db = new DatabaseContext();
            this.db = db;
            this.db_wp = db_wp;
            this._logger = _logger;
        }
        public async Task<Nace> getNaceById(int id){
            return await db.Nace.FirstOrDefaultAsync(w => w.naceId == id);
        }
        public async Task<Region> getRegionById(int id)
        {
            return await db.Region.FirstOrDefaultAsync(w => w.regionId == id);
        }
        public async Task<List<Nace>> getAllNaces()
        {
            return await db.Nace.ToListAsync();
        }

        public async Task<List<RegionWithHasData>> getAllRegionsWithHasData(int naceId, int tableId)
        {
            EuroStatTable table = await db.EuroStatTable.FirstAsync( table => table.tableId == tableId);
            string tableName = table.attributeName;
            System.Reflection.PropertyInfo prop = typeof(NaceRegionData).GetProperty(tableName);
            
            return db_wp.Region.ToList().Select(region => new RegionWithHasData 
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

        public async Task<List<NaceWithHasData>> getAllNacesWithHasData(int regionId, int tableId)
        {
            EuroStatTable table = await db.EuroStatTable.FirstAsync( table => table.tableId == tableId);
            string tableName = table.attributeName;
            System.Reflection.PropertyInfo prop = typeof(NaceRegionData).GetProperty(tableName);
            
            return db_wp.Nace.ToList().Select(nace => new NaceWithHasData 
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


        public async Task<List<Region>> getAllRegions()
        {
            return await db.Region.ToListAsync();
        }

        public async Task<List<NaceRegionData>> getAllNaceRegionData()
        {
            return await db_wp.NaceRegionData.ToListAsync();
        }

        public async Task<List<NaceRegionData>> getNaceRegionData(int? regionId, int? naceId, int? fromYear, int? toYear)
        {
            return await db_wp.NaceRegionData.Where(row => 
                (regionId == null || row.regionId == regionId) &&
                (naceId == null || row.naceId == naceId) &&
                (fromYear == null || row.year >= fromYear) && 
                (toYear == null || row.year <= toYear))
                .OrderBy(nrd => nrd.year)
                .ToListAsync();
        }

        public async Task<List<int>> getYearsWithData()
        {
            return await db.NaceRegionData
            .Select(nrd => nrd.year)
            .Distinct()
            .OrderBy(year => year)
            .ToListAsync();
        }

        public async Task<List<RegionData>> getAllRegionData()
        {
            return await db_wp.RegionData.ToListAsync();
        }

        public async Task<List<EuroStatTable>> getAllEuroStatTables()
        {
            return await db.EuroStatTable.ToListAsync();
        }

        public async Task<Nace> createNace(Nace nace)
        {
            await db.Nace.AddAsync(nace);
            db.SaveChanges();
            return nace;
        }

        public async Task<EuroStatTable> createEuroStatTable(EuroStatTable table)
        {
            await db.EuroStatTable.AddAsync(table);
            db.SaveChanges();
            return table;
        }
        public async Task<Region> createRegion(Region region)
        {
            await db.Region.AddAsync(region);
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
            return db_wp.RegionData.ToList();
        }

        public async Task<List<NaceRegionData>> addNaceRegionData(List<NaceRegionData> newNaceRegionData)
        {
            List<NaceRegionData> existingNaceRegionData = await db.NaceRegionData.ToListAsync();
            foreach (NaceRegionData newNRD in newNaceRegionData)
            {
                NaceRegionData existingElement = existingNaceRegionData.Find((exNRD) => exNRD.Equals(newNRD));
                if (existingElement == null)
                {
                    await db.NaceRegionData.AddAsync(newNRD);
                }
                else
                {
                    existingElement.merge(newNRD);
                }
            }
            db.SaveChanges();
            return await db_wp.NaceRegionData.ToListAsync();
        }
    }
}
