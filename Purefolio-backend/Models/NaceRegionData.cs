using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq; 

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

    public override bool Equals(object obj) 
        { 
            if (obj == null || GetType() != obj.GetType()) 
            { 
                return false; 
            } 
            NaceRegionData other = (NaceRegionData) obj; 
            return this.NaceId == other.NaceId && this.RegionId == other.RegionId && this.year == other.year; 
        } 
 
        public NaceRegionData merge(NaceRegionData other) 
        { 
          if(this.Equals(other)){ 
            List<System.Reflection.PropertyInfo> props = this.GetType().GetProperties().ToList(); 
            foreach (System.Reflection.PropertyInfo prop in props) 
            { 
                object value = prop.GetValue(other); 
                if(value != null) 
                { 
                  prop.SetValue(this, value); 
                } 
            } 
          } 
          return this; 
        } 
    }
}
