using System.ComponentModel.DataAnnotations;

namespace Purefolio_backend.Models
{
    public class Region
  {
    public int RegionId { get; set; }

    [Required]
    public string RegionCode { get; set; } // Primary key

    public string RegionName { get; set; }

    public int Area { get; set; }
  }
}
