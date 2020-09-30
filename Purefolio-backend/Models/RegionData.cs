using System.ComponentModel.DataAnnotations;

namespace Purefolio_backend.Models
{
    public class RegionData
    {
        [Key]
        public int regionDataId { get; set; }
        public int regionId { get; set; } // Foreign key
        [Required]
        public Region region { get; set; }

        public int year { get; set; }
        public int population { get; set; }
        // GDP in million of euros
        public int gdp { get; set; }
        public int corruptionRate { get; set; }
    }
}
