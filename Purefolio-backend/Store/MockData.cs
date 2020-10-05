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
    public class MockData

    {
        private readonly ILogger<MockData> _logger;

        private List<Nace> naces = new List<Nace>() {
                new Nace() {  naceCode = "A", naceName = "Agriculture, forestry and fishing" },
                new Nace() {  naceCode = "B", naceName = "Mining and quarrying" },
                new Nace() {  naceCode = "C", naceName = "Manufacturing" },
                new Nace() {  naceCode = "D", naceName = "Electricity, gas, steam and air conditioning supply" },
                new Nace() {  naceCode = "E", naceName = "Water supply; sewerage, waste management and remediation activities" },
                new Nace() {  naceCode = "F", naceName = "Construction" },
                new Nace() {  naceCode = "G", naceName = "Wholesale and retail trade; repair of motor vehicles and motorcycles"  },
                new Nace() {  naceCode = "H", naceName = "Transportation and storage" },
                new Nace() {  naceCode = "I", naceName = "Accommodation and food service activities" },
                new Nace() {  naceCode = "J", naceName = "Information and communication" },
                new Nace() {  naceCode = "K", naceName = "Financial and insurance activities" },
                new Nace() {  naceCode = "L", naceName = "Real estate activities" },
                new Nace() {  naceCode = "M", naceName = "Professional, scientific and technical activities" },
                new Nace() {  naceCode = "N", naceName = "Administrative and support service activities" },
                new Nace() {  naceCode = "O", naceName = "Public administration and defence; compulsory social security" },
                new Nace() {  naceCode = "P", naceName = "Education" },
                new Nace() {  naceCode = "Q", naceName = "Human health and social work activities" },
                new Nace() {  naceCode = "R", naceName = "Arts, entertainment and recreation" },
                new Nace() {  naceCode = "S", naceName = "Other service activities" },
                new Nace() {  naceCode = "T", naceName = "Activities of household as employers; undifferentiated goods- and services-producing activities of households for own account" },
                new Nace() {  naceCode = "U", naceName = "Activities of extraterritorial organisations and bodies" },
            };
        
        private List<Region> regions = new List<Region>() 
            { 
                new Region() { regionCode = "AT", regionName = "Austria", area = 83858 },
                new Region() { regionCode = "BE", regionName = "Belgium", area = 30510 },
                new Region() { regionCode = "BG", regionName = "Bulgaria", area = 110994 },
                new Region() { regionCode = "CH", regionName = "Switzerland", area = 41290 },
                new Region() { regionCode = "CY", regionName = "Cyprus", area = 9251 },
                new Region() { regionCode = "CZ", regionName = "Czechia", area = 78866},
                new Region() { regionCode = "DE", regionName = "Germany (until 1990 former territory of the FRG)", area = 357386},
                new Region() { regionCode = "DK", regionName = "Denmark", area = 44493 },
                new Region() { regionCode = "EE", regionName = "Estonia", area = 45339 },
                new Region() { regionCode = "EL", regionName = "Greece", area = 131940},
                new Region() { regionCode = "ES", regionName = "Spain", area = 498511 },
                new Region() { regionCode = "EU", regionName = "European Union - 27 countries (from 2020)"},
                new Region() { regionCode = "FI", regionName = "Finland", area = 338145 },
                new Region() { regionCode = "FR", regionName = "France", area = 551695 },
                new Region() { regionCode = "HR", regionName = "Croatia", area = 56594 },
                new Region() { regionCode = "HU", regionName = "Hungary", area = 93030 },
                new Region() { regionCode = "IE", regionName = "Ireland", area = 70273 },
                new Region() { regionCode = "IS", regionName = "Iceland", area = 102775 },
                new Region() { regionCode = "IT", regionName = "Italy", area = 301338 },
                new Region() { regionCode = "LT", regionName = "Lithuania", area = 65300 },
                new Region() { regionCode = "LU", regionName = "Luxembourg" , area = 2586 },
                new Region() { regionCode = "LV", regionName = "Latvia", area = 64589 },
                new Region() { regionCode = "MT", regionName = "Malta", area = 316 },
                new Region() { regionCode = "NL", regionName = "Netherlands", area = 41198 },
                new Region() { regionCode = "NO", regionName = "Norway", area = 385178 },
                new Region() { regionCode = "PL", regionName = "Poland", area = 312685 },
                new Region() { regionCode = "PT", regionName = "Portugal", area = 91568 },
                new Region() { regionCode = "RO", regionName = "Romania", area = 238397 },
                new Region() { regionCode = "RS", regionName = "Serbia", area = 77453 },
                new Region() { regionCode = "SE", regionName = "Sweden", area = 450295 },
                new Region() { regionCode = "SI", regionName = "Slovenia", area = 20273 },
                new Region() { regionCode = "SK", regionName = "Slovakia", area = 49036 },
                new Region() { regionCode = "TR", regionName = "Turkey", area = 783562 },
                new Region() { regionCode = "UK", regionName = "United Kingdom", area = 242495 },
            };

        private List<NaceRegionData> naceRegionData = new List<NaceRegionData>() 
            { 
                new NaceRegionData() { regionId = 1, naceId =15,  year = 2018, emissionPerYear = -1, genderPayGap = 14 },   
                new NaceRegionData() { regionId = 2, year = 2018, naceId = 15, emissionPerYear = -1, genderPayGap = 6.4 }, 
            };
        
        private List<RegionData> regionData = new List<RegionData>() 
            { 
                new RegionData() { regionId = 1,  corruptionRate = 84, year = 2019, population = 5328212, gdp = 360300 },
                new RegionData() {  regionId = 2, corruptionRate = 85, year = 2019, population = 10230185, gdp = 474194},
                new RegionData() { regionId = 3,  corruptionRate = 87, year = 2019, population = 5806081, gdp = 310002},
                new RegionData() { regionId = 3,  corruptionRate = 86, year = 2019, population = 5517919, gdp = 240557},
                new RegionData() {  regionId = 3, corruptionRate = 0, year = 2019, population = 446824564, gdp = 13953148},
                

            };

        public MockData(ILogger<MockData> _logger)
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
