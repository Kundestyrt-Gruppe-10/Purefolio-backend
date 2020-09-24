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
    public class MockDataStore

    {
        private readonly ILogger<MockDataStore> _logger;

        private List<Nace> naces = new List<Nace>() {

                new Nace() { NaceId = 0, NaceCode = "A", NaceName = "Agriculture, forestry and fishing" },

                new Nace() { NaceId = 1, NaceCode = "B", NaceName = "Mining and quarrying" },

                new Nace() { NaceId = 2, NaceCode = "C", NaceName = "Manufacturing" },

                new Nace() { NaceId = 3, NaceCode = "D", NaceName = "Electricity, gas, steam and air conditioning supply" },

                new Nace() { NaceId = 2, NaceCode = "E", NaceName = "Water supply; sewerage, waste management and remediation activities" },

                new Nace() { NaceId = 4, NaceCode = "F", NaceName = "Construction" },

                new Nace() { NaceId = 5, NaceCode = "G", NaceName = "Wholesale and retail trade; repair of motor vehicles and motorcycles"  },

                new Nace() { NaceId = 6, NaceCode = "H", NaceName = "Transportation and storage" },

                new Nace() { NaceId = 7, NaceCode = "I", NaceName = "Accommodation and food service activities" },

                new Nace() { NaceId = 8, NaceCode = "J", NaceName = "Information and communication" },

                new Nace() { NaceId = 9, NaceCode = "K", NaceName = "Financial and insurance activities" },

                new Nace() { NaceId = 10, NaceCode = "L", NaceName = "Real estate activities" },

                new Nace() { NaceId = 11, NaceCode = "M", NaceName = "Professional, scientific and technical activities" },

                new Nace() { NaceId = 12, NaceCode = "N", NaceName = "Administrative and support service activities" },

                new Nace() { NaceId = 13, NaceCode = "O", NaceName = "Public administration and defence; compulsory social security" },

                new Nace() { NaceId = 14, NaceCode = "P", NaceName = "Education" },

                new Nace() { NaceId = 15, NaceCode = "Q", NaceName = "Human health and social work activities" },

                new Nace() { NaceId = 16, NaceCode = "R", NaceName = "Arts, entertainment and recreation" },

                new Nace() { NaceId = 17, NaceCode = "S", NaceName = "Other service activities" },

                new Nace() { NaceId = 18, NaceCode = "T", NaceName = "Activities of household as employers; undifferentiated goods- and services-producing activities of households for own account" },

                new Nace() { NaceId = 19, NaceCode = "U", NaceName = "Activities of extraterritorial organisations and bodies" },

            };
        
        private List<Region> regions = new List<Region>() 
            { 
                new Region() { RegionId = 0, RegionCode = "NO", RegionName = "Norway" , Area = 2 },
                new Region() { RegionId = 1, RegionCode = "SE", RegionName = "Sweden" , Area = 2 },
                new Region() { RegionId = 2, RegionCode = "DK", RegionName = "Denmark", Area = 2 },
                new Region() { RegionId = 3, RegionCode = "FI", RegionName = "Finland", Area = 2 },
                new Region() { RegionId = 4, RegionCode = "EU", RegionName = "European Union", Area = 2 },
                

            };

        private List<NaceRegionData> naceRegionData = new List<NaceRegionData>() 
            { 
                new NaceRegionData() { RegionId = 0, year = 2018, NaceId = 0, emissionPerYer = -1, genderPayGap = 14 },   
                new NaceRegionData() { RegionId = 0, year = 2018, NaceId = 1, emissionPerYer = -1, genderPayGap = 6.4 }, 
            };
        
        private List<RegionData> regionData = new List<RegionData>() 
            { 
                new RegionData() { RegionDataId = 0, RegionId = 0, corruptionRate = 84, year = 2019, population = 5328212, gdp = 360300 },
                new RegionData() { RegionDataId = 1, RegionId = 1, corruptionRate = 85, year = 2019, population = 10230185, gdp = 474194},
                new RegionData() { RegionDataId = 2, RegionId = 2, corruptionRate = 87, year = 2019, population = 5806081, gdp = 310002},
                new RegionData() { RegionDataId = 3, RegionId = 3, corruptionRate = 86, year = 2019, population = 5517919, gdp = 240557},
                new RegionData() { RegionDataId = 4, RegionId = 4, corruptionRate = 0, year = 2019, population = 446824564, gdp = 13953148},
                

            };

        public MockDataStore(ILogger<MockDataStore> _logger)
        {
            this._logger = _logger;
        }      

        public List<Nace> getAllNaces()
        {
            return naces;
        }  

        public List<Region> getAllRegions()
        {
            return regions;
        }  

        public List<RegionData> getAllRegionData()
        {
            return regionData;
        }  

        public List<NaceRegionData> getAllNaceRegionData()
        {
            return naceRegionData;
        }  
    }
}
