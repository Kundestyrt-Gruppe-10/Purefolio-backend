using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq; 
using System;

namespace Purefolio_backend.Models
{
    public class NaceRegionData
  {
    [Key]
    public int naceRegionDataId { get; set; } // Primary key
    [Required]
    public virtual Nace nace { get; set; }
    [Required]
    public int naceId { get; set; } // Foreign key. Primary key
    [Required]
    public virtual Region region { get; set; } // Navigation property
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

    public static List<string> absolutelyMeasuredFields = new List<string>(){"emissionPerYear", "workAccidentsIncidentRate", "environmentTaxes", "fatalAccidentsAtWork","temporaryemployment"};

    public NaceRegionData comparedByArea()
    {
      foreach (string absoluteAttribute in NaceRegionData.absolutelyMeasuredFields)
      {
          System.Reflection.PropertyInfo prop = this.GetType().GetProperty(absoluteAttribute);
          if (prop.GetValue(this) != null && this.region.area != 0) {
            double value = (double) prop.GetValue(this) / (double) this.region.area;
            prop.SetValue(this, value);
          }
      }
      return this;
    }

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
            Console.WriteLine("GetType: " + GetType().ToString() + ", obj.GetType: " + obj.GetType().ToString());
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
