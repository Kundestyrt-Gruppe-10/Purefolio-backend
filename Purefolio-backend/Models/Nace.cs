using System;
using System.ComponentModel.DataAnnotations;

namespace Purefolio_backend.Models
{
    public class Nace
  {
    public int NaceId { get; set; }

    [Required]
    public string NaceCode { get; set; } // Primary key
    public string NaceName { get; set; }

    public override bool Equals(object obj)
    {
      return obj is Nace nace && NaceCode == nace.NaceCode;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(NaceCode);
    }

    public override string ToString()
      {
            return NaceCode + " - " + NaceName;
      }
  }
}
