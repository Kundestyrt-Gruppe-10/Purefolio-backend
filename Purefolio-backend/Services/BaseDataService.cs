<<<<<<< master:Purefolio-backend/Services/BaseDataService.cs
﻿using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purefolio_backend.Services
{
    public class BaseDataService
    {
        private readonly ILogger<BaseDataService> _logger;
        private readonly DatabaseStore ds;
        private BaseData baseData;
        public BaseDataService(ILogger<BaseDataService> _logger,
            DatabaseStore ds,
            BaseData baseData)
        {
            this._logger = _logger;
            this.ds = ds;
            this.baseData = baseData;
        }
        public string PopulateDatabase()
        {
            List<Nace> savedNaces = ds.getAllNaces();
            List<Region> savedRegions = ds.getAllRegions();
            List<EuroStatTable> savedTables = ds.getAllEuroStatTables();
            foreach(Nace nace in baseData.getAllNaces())
            {
                try
                { 
                    if(!savedNaces.Contains(nace)){
                        ds.createNace(nace);
                    }
                    
                } catch(Exception exception)
                {
                    _logger.LogError(exception.ToString());
                    return exception.ToString();
                }
            }
            foreach(Region region in baseData.getAllRegions())
            {
                try
                { 
                    if(!savedRegions.Contains(region)){
                        ds.createRegion(region);
                    }
                } catch(Exception exception)
                {
                    _logger.LogError(exception.ToString());
                    return exception.ToString();
                }
            }
            foreach(EuroStatTable table in baseData.getAllEuroStatTables())
            {
                try
                { 
                    if(!savedTables.Contains(table)){
                        ds.createTable(table);
                    }
                } catch(Exception exception)
                {
                    _logger.LogError(exception.ToString());
                    return exception.ToString();
                }
            }
            return "The base data was added successfully";
        }
    }
}
=======
﻿using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purefolio_backend.Services
{
    public class MockDataService
    {
        private readonly ILogger<MockDataService> _logger;
        private readonly DatabaseStore ds;
        private MockData mockData;
        public MockDataService(ILogger<MockDataService> _logger,
            DatabaseStore ds,
            MockData mockData)
        {
            this._logger = _logger;
            this.ds = ds;
            this.mockData = mockData;
        }
        public Boolean PopulateDatabase()
        {
            foreach(Nace nace in mockData.getAllNaces())
            {
                try
                {
                    ds.createNace(nace);
                } catch(Exception exception)
                {
                    _logger.LogError(exception.ToString());
                    return false;
                }
            }
            foreach(Region region in mockData.getAllRegions())
            {
                try
                {
                    ds.createRegion(region);
                } catch(Exception exception)
                {
                    _logger.LogError(exception.ToString());
                    return false;
                }
            }
            List<EuroStatTable> savedTables = ds.getAllEuroStatTables();
            foreach(EuroStatTable table in mockData.getAllEuroStatTables())
            {
                try
                {
                    if(!savedTables.Contains(table))
                    {
                        ds.createEuroStatTable(table);
                    }
                    
                } catch(Exception exception)
                {
                    _logger.LogError(exception.ToString());
                    return false;
                }
            }

            // This depends on Region to be populated first
            foreach(RegionData regionData in mockData.getAllRegionData())
            {
                Region region = ds.getRegionById(regionData.regionId); // Throws exception if not exists
                regionData.region = region;
                try
                {
                    ds.createRegionData(regionData
                    );
                } catch(Exception exception)
                {
                    _logger.LogError(exception.ToString());
                    return false;
                }
            }
            // This depends on Nace and Region to be populated first
            foreach(NaceRegionData naceRegionData in mockData.getAllNaceRegionData())
            {
                Nace nace = ds.getNaceById(naceRegionData.naceId);
                Region region = ds.getRegionById(naceRegionData.regionId);
                naceRegionData.nace = nace;
                naceRegionData.region = region;
                try
                {
                    ds.createNaceRegionData(naceRegionData);
                } catch(Exception ex)
                {
                    _logger.LogError(ex.ToString());
                    return false;
                }
            }
            return true;
        }

    }
}
>>>>>>> Add populating of EuroStatTable-objects, not working yet:Purefolio-backend/Services/MockDataService.cs
