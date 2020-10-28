using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purefolio_backend.Models
{
    public class Nace
  {
    public int naceId { get; set; }

    [Required]
    [Index(IsUnique = true)]
    public string naceCode { get; set; } // Primary key
    public string naceName { get; set; }

    public override bool Equals(object obj)
    {
      return obj is Nace nace && naceCode == nace.naceCode;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(naceCode);
    }

    public override string ToString()
      {
            return naceCode + " - " + naceName;
      }
  }

  public class NaceHasData : Nace
  {
    public bool hasData { get; set; }
  }
}
