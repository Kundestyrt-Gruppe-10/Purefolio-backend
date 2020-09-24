using System.ComponentModel.DataAnnotations;

namespace Purefolio_backend.Models
{
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
}
