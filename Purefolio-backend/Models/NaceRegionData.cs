using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq; 

namespace Purefolio_backend.Models
{
    public class NaceRegionData
  {
    [Key]
    public int naceRegionDataId { get; set; } // Primary key
    [Required]
    public Nace nace { get; set; }
    public int naceId { get; set; } // Foreign key. Primary key
    [Required]
    public Region region { get; set; } // Navigation property
    public int regionId { get; set; } // Foreign key. Primary key
    public int year { get; set; }
    public double? emissionPerYer { get; set; }
    public double? genderPayGap { get; set; }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override bool Equals(object obj) 
    { 
        if (obj == null || GetType() != obj.GetType()) 
        { 
            return false; 
        } 
        NaceRegionData other = (NaceRegionData) obj; 
        return this.naceId == other.naceId && this.regionId == other.regionId && this.year == other.year; 
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
