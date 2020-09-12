using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

// TODO: Move models to seperate files?
namespace Purefolio_backend.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        [Required]
        public string RegionCode { get; set; } // Primary key
    }
    public class Nace
    {
        public int NaceId { get; set; }
        [Required]
        public string NaceCode { get; set; } // Primary key

        public override bool Equals(object obj)
        {
            return obj is Nace nace &&
                   NaceCode == nace.NaceCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NaceCode);
        }

        public override string ToString()
        {
            return NaceCode.ToString();
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
        public string emissionPerYer { get; set; }
        public string genderPayGap { get; set; }
        public string corruptionRate { get; set; }
    }
    public class RegionData
    {
        public int RegionDataId { get; set; }
        public int RegionDetailId { get; set; }
        public string RegionEmission { get; set; } // Foreign key

    }

}
