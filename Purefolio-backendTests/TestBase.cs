
using System;
using Microsoft.EntityFrameworkCore;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
namespace Purefolio_backend
{
    public class PurefolioTestBase: IDisposable{

        protected readonly DatabaseContext _context; 

        public PurefolioTestBase()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName:Guid.NewGuid().ToString())
            .Options;

            _context = new DatabaseContext(options);

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
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

    }

}