using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purefolio_backend.Models
{
    public class Region
  {
    [Key]
    public int regionId { get; set; }

    [Required]
    [Index(IsUnique = true)]
    public string regionCode { get; set; } // Primary key

    public string regionName { get; set; }

    public int area { get; set; }

    public override bool Equals(object obj)
    {
      return obj is Region region && regionCode == region.regionCode;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(regionCode);
    }

    public override string ToString()
      {
            return regionName;
      }
  }
}
