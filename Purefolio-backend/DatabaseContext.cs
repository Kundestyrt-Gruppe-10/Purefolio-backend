using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Purefolio.DatabaseContext;

namespace Purefolio.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Region> Region { get; set; }
        public DbSet<Nace> Nace { get; set; }
        public DbSet<RegionData> RegionData { get; set; }
        public DbSet<NaceRegionData> NaceRegionData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
            // TODO: Use a configuration file instead of hard coding database string.
            .UseNpgsql("Host=localhost;Port=10101;Database=purefolio;Username=purefolio;Password=password")
            .UseSnakeCaseNamingConvention();
    }

    // TODO: Move out to seperate file
    public class Nace
    {
        public int NaceId { get; set; }
        [Required]
        public string NaceCode { get; set; } // Primary key
    }
    public class Region
    {
        public int RegionId { get; set; }
        [Required]
        public string RegionCode { get; set; } // Primary key
    }
    public class RegionData
    {
        public int RegionDataId { get; set; }
        public int RegionDetailId { get; set; }
        public string RegionEmission { get; set; } // Foreign key

    }


    public class NaceRegionData
    {
        public int NaceRegionDataId{ get; set; } // Primary key
        [Required]
        public int NaceId { get; set; } // Foreign key. Primary key
        [Required]
        public Nace Nace { get; set; }
        [Required]
        public int RegionId { get; set; } // Foreign key. Primary key
        [Required]
        public Region Region { get; set; } // Nacigation property
        public int year { get; set; }
        public string emissionPerYer { get; set; }
        public string genderPayGap { get; set; }
        public string corruptionRate { get; set; }
    }


}

