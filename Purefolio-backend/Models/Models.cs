using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// TODO: Move models to seperate files?
namespace Purefolio_backend.Models
{
  public class Region
  {
    public int RegionId { get; set; }

    [Required]
    public string RegionCode { get; set; } // Primary key

    public string RegionName { get; set; }

    public int Area { get; set; }
  }

  public class Nace
  {
    public int NaceId { get; set; }

    [Required]
    public string NaceCode { get; set; } // Primary key
    public string NaceName { get; set; }

    public override bool Equals(object obj)
    {
      return obj is Nace nace && NaceCode == nace.NaceCode;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(NaceCode);
    }

    public override string ToString()
      {
            return NaceCode + " - " + NaceName;
      }
  }

  public class NaceRegionData
  {
   public int NaceRegionDataId { get; set; } // Primary key
        [Required]
        public int NaceId { get; set; } // Foreign key. Primary key
        [Required]
        public Nace Nace { get; set; }
        [Required]
        public int RegionId { get; set; } // Foreign key. Primary key
        [Required]
        public Region Region { get; set; } // Navigation property
        public int year { get; set; }
        public double emissionPerYer { get; set; }
        public double genderPayGap { get; set; }
    }
    public class RegionData
    {
        public int RegionDataId { get; set; }
        public int RegionId { get; set; } // Foreign key

        public int year { get; set; }
        public int population { get; set; }
        // GDP in million of euros
        public int gdp { get; set; }
        public int corruptionRate { get; set; }
    }
}
