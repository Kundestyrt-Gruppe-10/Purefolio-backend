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
    [Required]
    public int naceId { get; set; } // Foreign key. Primary key
    [Required]
    public Region region { get; set; } // Navigation property
    [Required]
    public int regionId { get; set; } // Foreign key. Primary key
    [Required]
    public int year { get; set; }
    public double? emissionPerYear { get; set; }
    public double? genderPayGap { get; set; }
    public double? workAccidentsIncidentRate { get; set; }
    public double? environmentTaxes { get; set; }
    public double? fatalAccidentsAtWork { get; set; }
    public double? temporaryemployment { get; set; }
    public double? employeesPrimaryEducation { get; set; }
    public double? employeesSecondaryEducation { get; set; }
    public double? employeesTertiaryEducation { get; set; }

    

    public static List<string> essentialFields = new List<string>(){"naceRegionDataId", "region", "regionId", "nace", "naceId", "year"};

    public List<System.Reflection.PropertyInfo> getDataProperties()
    {
      return this.GetType().GetProperties().Where(prop => !essentialFields.Contains(prop.Name)).ToList();
    }

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
        List<System.Reflection.PropertyInfo> props = getDataProperties();
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
