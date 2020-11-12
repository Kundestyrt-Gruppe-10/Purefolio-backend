using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Purefolio_backend.Models;
using System;

namespace Purefolio.DatabaseContext
{
  public class DatabaseContext : DbContext
  {
    public DbSet<Region> Region { get; set; }

    public DbSet<Nace> Nace { get; set; }

    public DbSet<RegionData> RegionData { get; set; }

    public DbSet<NaceRegionData> NaceRegionData { get; set; }

    public DbSet<EuroStatTable> EuroStatTable { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { 
      // Set connection timeOut to 3 min. It takes a long time to intialize the database
      if (!isTestDatabase())
      {
          this.Database.SetCommandTimeout(180);
      }
      
    }

    protected bool isTestDatabase () => this.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory";

    protected override void OnConfiguring(
      DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
          //.UseNpgsql("Host=localhost;Port=10101;Database=purefolio;Username=purefolio;Password=password")
          //.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"])
          .EnableSensitiveDataLogging() // TODO: Remove before production
          .UseSnakeCaseNamingConvention();

    }
    // This initialises database with tables on startup
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Region>().ToTable("Region");
      modelBuilder.Entity<Nace>().ToTable("Nace");
      modelBuilder.Entity<RegionData>().ToTable("RegionData");
      modelBuilder.Entity<NaceRegionData>().ToTable("NaceRegionData");
      modelBuilder.Entity<EuroStatTable>().ToTable("EuroStatTable");
    }
  }
  
  // DatabaseContextWithProxy is exactly the same as DatabaseContext (without the constructor).
  // The main difference is given as argument in Startup.cs. 
  // WithProxy uses UseLazyLoadingProxies() to return related objects as well as attributes in the database table.
  public class DatabaseContextWithProxy : DbContext
  {
    public DbSet<Region> Region { get; set; }

    public DbSet<Nace> Nace { get; set; }

    public DbSet<RegionData> RegionData { get; set; }

    public DbSet<NaceRegionData> NaceRegionData { get; set; }

    public DbSet<EuroStatTable> EuroStatTable { get; set; }
    public DatabaseContextWithProxy(DbContextOptions<DatabaseContextWithProxy> options) : base(options) {}

    protected override void OnConfiguring(
      DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
          //.UseNpgsql("Host=localhost;Port=10101;Database=purefolio;Username=purefolio;Password=password")
          //.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"])
          .EnableSensitiveDataLogging() // TODO: Remove before production
          .UseSnakeCaseNamingConvention();

    }
    // This initialises database with tables on startup
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Region>().ToTable("Region");
      modelBuilder.Entity<Nace>().ToTable("Nace");
      modelBuilder.Entity<RegionData>().ToTable("RegionData");
      modelBuilder.Entity<NaceRegionData>().ToTable("NaceRegionData");
      modelBuilder.Entity<EuroStatTable>().ToTable("EuroStatTable");
    }
  }
  
}
