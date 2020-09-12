using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;

namespace Purefolio.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Region> Region { get; set; }

        public DbSet<Nace> Nace { get; set; }

        public DbSet<RegionData> RegionData { get; set; }

        public DbSet<NaceRegionData> NaceRegionData { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        ) =>
            optionsBuilder // TODO: Use a configuration file instead of hard coding database string.
                .UseNpgsql("Host=localhost;Port=10101;Database=purefolio;Username=purefolio;Password=password")
                .UseSnakeCaseNamingConvention();

        // This initialises database with tables on startup
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<Nace>().ToTable("Nace");
            modelBuilder.Entity<RegionData>().ToTable("RegionData");
            modelBuilder.Entity<NaceRegionData>().ToTable("NaceRegionData");
        }
    }
}
