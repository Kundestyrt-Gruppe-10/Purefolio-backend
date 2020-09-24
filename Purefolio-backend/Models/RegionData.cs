namespace Purefolio_backend.Models
{
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
