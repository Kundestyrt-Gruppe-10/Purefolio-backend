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
    public class BaseData

    {
        protected List<Nace> naces = new List<Nace>() {
                new Nace() {  naceCode = "A", naceName = "Agriculture, forestry and fishing" },
                new Nace() {  naceCode = "A01", naceName = "Crop and animal production, hunting and related service activities" },
                new Nace() {  naceCode = "A02", naceName = "Forestry and logging" },
                new Nace() {  naceCode = "A03", naceName = "Fishing and aquaculture" },
                new Nace() {  naceCode = "B", naceName = "Mining and quarrying" },
                new Nace() {  naceCode = "B05", naceName = "Mining of coal and lignite" },
                new Nace() {  naceCode = "B06", naceName = "Extraction of crude petroleum and natural gas" },
                new Nace() {  naceCode = "B07", naceName = "Mining of metal ores" },
                new Nace() {  naceCode = "B08", naceName = "Other mining and quarrying" },
                new Nace() {  naceCode = "B09", naceName = "Mining support service activities" },
                new Nace() {  naceCode = "C", naceName = "Manufacturing" },
                new Nace() {  naceCode = "C10", naceName = "Manufacture of food products" },
                new Nace() {  naceCode = "C11", naceName = "Manufacture of beverages" },
                new Nace() {  naceCode = "C12", naceName = "Manufacture of tobacco products" },
                new Nace() {  naceCode = "C13", naceName = "Manufacture of textiles" },
                new Nace() {  naceCode = "C14", naceName = "Manufacture of wearing apparel" },
                new Nace() {  naceCode = "C15", naceName = "Manufacture of leather and related products" },
                new Nace() {  naceCode = "C16", naceName = "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                new Nace() {  naceCode = "C17", naceName = "Manufacture of paper and paper product" },
                new Nace() {  naceCode = "C18", naceName = "Printing and reproduction of recorded media" },
                new Nace() {  naceCode = "C19", naceName = "Manufacture of coke and refined petroleum products" },
                new Nace() {  naceCode = "C20", naceName = "Manufacture of chemicals and chemical products" },
                new Nace() {  naceCode = "C21", naceName = "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                new Nace() {  naceCode = "C22", naceName = "Manufacture of rubber and plastic products" },
                new Nace() {  naceCode = "C23", naceName = "anufacture of other non-metallic mineral products" },
                new Nace() {  naceCode = "C24", naceName = "Manufacture of basic metals" },
                new Nace() {  naceCode = "C25", naceName = "Manufacture of basic metals" },
                new Nace() {  naceCode = "C26", naceName = "Manufacture of computer, electronic and optical products" },
                new Nace() {  naceCode = "C27", naceName = "Manufacture of electrical equipment" },
                new Nace() {  naceCode = "C28", naceName = "Manufacture of machinery and equipment n.e.c." },
                new Nace() {  naceCode = "C29", naceName = "Manufacture of motor vehicles, trailers and semi-trailers" },
                new Nace() {  naceCode = "C30", naceName = "Manufacture of other transport equipment" },
                new Nace() {  naceCode = "C31", naceName = "Manufacture of furniture" },
                new Nace() {  naceCode = "C32", naceName = "Other manufacturing" },
                new Nace() {  naceCode = "C33", naceName = "Repair and installation of machinery and equipment" },
                new Nace() {  naceCode = "D", naceName = "Electricity, gas, steam and air conditioning supply" },
                new Nace() {  naceCode = "E", naceName = "Water supply; sewerage, waste management and remediation activities" },
                new Nace() {  naceCode = "E36", naceName = "Water collection, treatment and supply" },
                new Nace() {  naceCode = "E37", naceName = "Sewerage" },
                new Nace() {  naceCode = "E38", naceName = "Waste collection, treatment and disposal activities; materials recovery" },
                new Nace() {  naceCode = "E39", naceName = "Remediation activities and other waste management services" },
                new Nace() {  naceCode = "F", naceName = "Construction" },
                new Nace() {  naceCode = "F41", naceName = "Construction of buildings" },
                new Nace() {  naceCode = "F42", naceName = "Civil engineering" },
                new Nace() {  naceCode = "F43", naceName = "Specialised construction activities" },
                new Nace() {  naceCode = "G", naceName = "Wholesale and retail trade; repair of motor vehicles and motorcycles"  },
                new Nace() {  naceCode = "G45", naceName = "Wholesale and retail trade and repair of motor vehicles and motorcycles"  },
                new Nace() {  naceCode = "G46", naceName = "Wholesale trade, except of motor vehicles and motorcycles"  },
                new Nace() {  naceCode = "G47", naceName = "Retail trade, except of motor vehicles and motorcycles"  },
                new Nace() {  naceCode = "H", naceName = "Transportation and storage" },
                new Nace() {  naceCode = "H49", naceName = "Land transport and transport via pipelines" },
                new Nace() {  naceCode = "H50", naceName = "Water transport" },
                new Nace() {  naceCode = "H51", naceName = "Air transport" },
                new Nace() {  naceCode = "H52", naceName = "Warehousing and support activities for transportation" },
                new Nace() {  naceCode = "H53", naceName = "Postal and courier activities" },
                new Nace() {  naceCode = "I", naceName = "Accommodation and food service activities" },
                new Nace() {  naceCode = "I55", naceName = "Accommodation" },
                new Nace() {  naceCode = "I56", naceName = "Food and beverage service activities" },
                new Nace() {  naceCode = "J", naceName = "Information and communication" },
                new Nace() {  naceCode = "J58", naceName = "Publishing activities" },
                new Nace() {  naceCode = "J59", naceName = "Motion picture, video and television programme production, sound recording and music publishing activities" },
                new Nace() {  naceCode = "J60", naceName = "Programming and broadcasting activities" },
                new Nace() {  naceCode = "J61", naceName = "Telecommunications" },
                new Nace() {  naceCode = "J62", naceName = "Computer programming, consultancy and related activities " },
                new Nace() {  naceCode = "J63", naceName = "Information service activities" },
                new Nace() {  naceCode = "K", naceName = "Financial and insurance activities" },
                new Nace() {  naceCode = "K64", naceName = "Financial service activities, except insurance and pension funding" },
                new Nace() {  naceCode = "K65", naceName = "Insurance, reinsurance and pension funding, except compulsory social security" },
                new Nace() {  naceCode = "K66", naceName = "Activities auxiliary to financial services and insurance activities" },
                new Nace() {  naceCode = "L", naceName = "Real estate activities" },
                new Nace() {  naceCode = "M", naceName = "Professional, scientific and technical activities" },
                new Nace() {  naceCode = "M69", naceName = "Legal and accounting activities" },
                new Nace() {  naceCode = "M70", naceName = "Activities of head offices; management consultancy activities" },
                new Nace() {  naceCode = "M71", naceName = "Architectural and engineering activities; technical testing and analysis" },
                new Nace() {  naceCode = "M72", naceName = "Scientific research and development" },
                new Nace() {  naceCode = "M73", naceName = "Advertising and market research" },
                new Nace() {  naceCode = "M74", naceName = "Other professional, scientific and technical activities" },
                new Nace() {  naceCode = "M75", naceName = "Veterinary activities" },
                new Nace() {  naceCode = "N", naceName = "Administrative and support service activities" },
                new Nace() {  naceCode = "N77", naceName = "Rental and leasing activities" },
                new Nace() {  naceCode = "N78", naceName = "Employment activities" },
                new Nace() {  naceCode = "N79", naceName = "Travel agency, tour operator and other reservation service and related activities" },
                new Nace() {  naceCode = "N80", naceName = "Security and investigation activities" },
                new Nace() {  naceCode = "N81", naceName = "Services to buildings and landscape activities" },
                new Nace() {  naceCode = "N82", naceName = "Office administrative, office support and other business support activities" },
                new Nace() {  naceCode = "O", naceName = "Public administration and defence; compulsory social security" },
                new Nace() {  naceCode = "P", naceName = "Education" },
                new Nace() {  naceCode = "Q", naceName = "Human health and social work activities" },
                new Nace() {  naceCode = "Q86", naceName = "Human health activities" },
                new Nace() {  naceCode = "Q87", naceName = "Residential care activities" },
                new Nace() {  naceCode = "Q88", naceName = "Social work activities without accommodation" },
                new Nace() {  naceCode = "R", naceName = "Arts, entertainment and recreation" },
                new Nace() {  naceCode = "R90", naceName = "Creative, arts and entertainment activities" },
                new Nace() {  naceCode = "R91", naceName = "Libraries, archives, museums and other cultural activities" },
                new Nace() {  naceCode = "R92", naceName = "Gambling and betting activities" },
                new Nace() {  naceCode = "R93", naceName = "Sports activities and amusement and recreation activities" },
                new Nace() {  naceCode = "S", naceName = "Other service activities" },
                new Nace() {  naceCode = "S94", naceName = "Activities of membership organisations" },
                new Nace() {  naceCode = "S95", naceName = "Repair of computers and personal and household goods" },
                new Nace() {  naceCode = "S96", naceName = "Other personal service activities" },
                new Nace() {  naceCode = "T", naceName = "Activities of household as employers; undifferentiated goods- and services-producing activities of households for own account" },
                new Nace() {  naceCode = "T97", naceName = "Activities of households as employers of domestic personnel" },
                new Nace() {  naceCode = "T98", naceName = "Undifferentiated goods- and services-producing activities of private households for own use" },
                new Nace() {  naceCode = "U", naceName = "Activities of extraterritorial organisations and bodies" },
                new Nace() {  naceCode = "TOTAL", naceName = "Total - All NACE activities" },
            };
        
        protected List<Region> regions = new List<Region>() 
            { 
                new Region() { regionCode = "AT", regionName = "Austria", area = 83858 },
                new Region() { regionCode = "BE", regionName = "Belgium", area = 30510 },
                new Region() { regionCode = "BG", regionName = "Bulgaria", area = 110994 },
                new Region() { regionCode = "CH", regionName = "Switzerland", area = 41290 },
                new Region() { regionCode = "CY", regionName = "Cyprus", area = 9251 },
                new Region() { regionCode = "CZ", regionName = "Czechia", area = 78866},
                new Region() { regionCode = "DE", regionName = "Germany", area = 357386},
                new Region() { regionCode = "DK", regionName = "Denmark", area = 44493 },
                new Region() { regionCode = "EE", regionName = "Estonia", area = 45339 },
                new Region() { regionCode = "EL", regionName = "Greece", area = 131940},
                new Region() { regionCode = "ES", regionName = "Spain", area = 498511 },
                new Region() { regionCode = "EU27_2020", regionName = "European Union - 27 countries (from 2020)"},
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

        protected List<EuroStatTable> euroStatTables = new List<EuroStatTable>()
        {
            new EuroStatTable(){tableCode = "env_ac_ainah_r2", attributeName = "emissionPerYear", dataType="NaceRegionData", unit="unit=KG_HAB&airpol=GHG"},
            new EuroStatTable(){tableCode = "hsw_n2_03", attributeName = "workAccidentsIncidentRate", dataType="NaceRegionData", unit="unit=RT_INC&age=TOTAL"},
            new EuroStatTable(){tableCode = "earn_gr_gpgr2", attributeName = "genderPayGap", dataType="NaceRegionData", unit="unit=PC"},
            new EuroStatTable(){tableCode = "env_ac_taxind2", attributeName = "environmentTaxes", dataType="NaceRegionData", unit="tax=ENV&unit=MIO_EUR"},
            new EuroStatTable(){tableCode = "hsw_n2_02", attributeName = "fatalAccidentsAtWork", dataType="NaceRegionData", unit="unit=RT_INC"},
            new EuroStatTable(){tableCode = "lfsa_etgan2", attributeName = "temporaryemployment", dataType="NaceRegionData", unit="sex=T&unit=THS&age=Y15-74"},
            new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesPrimaryEducation", dataType="NaceRegionData", unit="sex=T&unit=PC&isced11=ED0-2&age=Y15-74"},
            new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesSecondaryEducation", dataType="NaceRegionData", unit="sex=T&unit=PC&isced11=ED3_4&age=Y15-74"},
            new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesTertiaryEducation", dataType="NaceRegionData", unit="sex=T&unit=PC&isced11=ED5-8&age=Y15-74"}


        };

        public List<Nace> getAllNaces()
        {
            return naces;
        }  

        public List<Region> getAllRegions()
        {
            return regions;
        }  

        public List<EuroStatTable> getAllEuroStatTables()
        {
            return euroStatTables;
        }
    }

    public class MockData : BaseData
    {
        private List<NaceRegionData> naceRegionData = new List<NaceRegionData>() 
            { 
                new NaceRegionData() { regionId = 1, naceId =15,  year = 2018, genderPayGap = 14 },   
                new NaceRegionData() { regionId = 2, naceId = 15, year = 2018, genderPayGap = 6.4 },
            };
        
        private List<RegionData> regionData = new List<RegionData>() 
            { 
                new RegionData() { regionId = 1,  corruptionRate = 84, year = 2019, population = 5328212, gdp = 360300 },
                new RegionData() { regionId = 2, corruptionRate = 85, year = 2019, population = 10230185, gdp = 474194},
                new RegionData() { regionId = 3,  corruptionRate = 87, year = 2019, population = 5806081, gdp = 310002},
                new RegionData() { regionId = 4,  corruptionRate = 86, year = 2019, population = 5517919, gdp = 240557},
                new RegionData() { regionId = 5, corruptionRate = 0, year = 2019, population = 446824564, gdp = 13953148},
                new RegionData() { regionId = 1, year = 2018 },
                new RegionData() { regionId = 2, year = 2018 },
                new RegionData() { regionId = 3, year = 2018 },
                new RegionData() { regionId = 4, year = 2018 },
                new RegionData() { regionId = 5, year = 2018 },
                

            };   
    

        public new List<Nace> getAllNaces()
        {
            return this.naces.Take(5).ToList();
        }

        public new List<Region> getAllRegions()
        {
            return this.regions.Take(5).ToList();
        }

        public List<NaceRegionData> getNaceRegionData()
        {
            return this.naceRegionData;
        }

        public List<RegionData> getRegionData()
        {
            return this.regionData;
        }
    }
}
