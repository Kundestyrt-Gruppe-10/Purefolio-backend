using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq; 


namespace Purefolio_backend.Models
{
    public class RegionData
    {
        [Key]
        public int regionDataId { get; set; }
        [Required]
        public int regionId { get; set; } // Foreign key
        [Required]
        public Region region { get; set; }
        [Required]
        public int year { get; set; }
        public int? population { get; set; }
        // GDP in million of euros
        public int? gdp { get; set; }
        public int? corruptionRate { get; set; }

        public static List<string> essentialFields = new List<string>(){
          "regionDataId", "regionId", "region", "year"
        };

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
        RegionData other = (RegionData) obj; 
        return this.regionId == other.regionId && this.year == other.year; 
    } 

    public RegionData merge(RegionData other) 
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
