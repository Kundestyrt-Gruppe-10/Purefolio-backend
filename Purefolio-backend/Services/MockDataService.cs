using Microsoft.Extensions.Logging;
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
