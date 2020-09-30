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
  }
}
