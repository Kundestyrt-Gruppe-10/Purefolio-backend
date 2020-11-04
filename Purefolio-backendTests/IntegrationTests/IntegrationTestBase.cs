
using System;
using Microsoft.EntityFrameworkCore;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
namespace Purefolio_backend
{
    public class IntegrationTestBase: IDisposable{

        protected readonly DatabaseContext _context; 
        protected readonly DatabaseContextWithProxy _context_wp; 

        public IntegrationTestBase()
        {
            string databaseName = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName:databaseName)
            .Options;

            _context = new DatabaseContext(options);

            var options_wp = new DbContextOptionsBuilder<DatabaseContextWithProxy>()
            .UseInMemoryDatabase(databaseName:databaseName)
            .Options;

            _context_wp = new DatabaseContextWithProxy(options_wp);

            _context.Database.EnsureCreated();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            _context.Nace.AddRange(new Nace[]{
                    new Nace() {  naceCode = "A", naceName = "Agriculture, forestry and fishing" },
                    new Nace() {  naceCode = "B", naceName = "Mining and quarrying" },
                    new Nace() {  naceCode = "C", naceName = "Manufacturing" },
            });
            _context.Region.AddRange(new Region[]{
                new Region() { regionCode = "AT", regionName = "Austria", area = 83858 },
                new Region() { regionCode = "BE", regionName = "Belgium", area = 30510 },
                new Region() { regionCode = "BG", regionName = "Bulgaria", area = 110994 },
            });
            _context.NaceRegionData.AddRange(new NaceRegionData[]{
                new NaceRegionData() { regionId = 1, naceId = 15,  year = 2018, genderPayGap = 14 },   
                new NaceRegionData() { regionId = 2, naceId = 15, year = 2018, genderPayGap = 6.4 },
            });
            _context.RegionData.AddRange(new RegionData[]{
                new RegionData() { regionId = 1,  corruptionRate = 84, year = 2019, population = 5328212, gdp = 360300 },
                new RegionData() { regionId = 2, corruptionRate = 85, year = 2019, population = 10230185, gdp = 474194},
                new RegionData() { regionId = 3,  corruptionRate = 87, year = 2019, population = 5806081, gdp = 310002},
            });
            _context.EuroStatTable.AddRange(new EuroStatTable[]{
                new EuroStatTable(){tableCode = "env_ac_ainah_r2", attributeName = "emissionPerYear", dataType="NaceRegionData", filters="unit=KG_HAB&airpol=GHG"},
                new EuroStatTable(){tableCode = "hsw_n2_03", attributeName = "workAccidentsIncidentRate", dataType="NaceRegionData", filters="unit=RT_INC&age=TOTAL"},
                new EuroStatTable(){tableCode = "earn_gr_gpgr2", attributeName = "genderPayGap", dataType="NaceRegionData", filters="unit=PC"},
                new EuroStatTable(){tableCode = "env_ac_taxind2", attributeName = "environmentTaxes", dataType="NaceRegionData", filters="tax=ENV&unit=MIO_EUR"},
                new EuroStatTable(){tableCode = "hsw_n2_02", attributeName = "fatalAccidentsAtWork", dataType="NaceRegionData", filters="unit=RT_INC"},
                new EuroStatTable(){tableCode = "lfsa_etgan2", attributeName = "temporaryemployment", dataType="NaceRegionData", filters="sex=T&unit=THS&age=Y15-74"},
                new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesPrimaryEducation", dataType="NaceRegionData", filters="sex=T&unit=PC&isced11=ED0-2&age=Y15-74"},
                new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesSecondaryEducation", dataType="NaceRegionData", filters="sex=T&unit=PC&isced11=ED3_4&age=Y15-74"},
                new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesTertiaryEducation", dataType="NaceRegionData", filters="sex=T&unit=PC&isced11=ED5-8&age=Y15-74"}
            });
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

    }

}