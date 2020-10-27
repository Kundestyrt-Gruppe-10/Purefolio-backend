using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purefolio_backend.Models
{
    public class EuroStatTable
  {
    [Key]
    public int tableId { get; set; }
    public string tableCode { get; set; }
    public string attributeName { get; set; }
    public string filters { get; set; }
    public string dataType { get; set; }
    public string unit { get; set; }
    public string datasetName { get; set; }
    public string esgFactor { get; set; }
    public string description { get; set; }
    public string href { get; set;}


    public override bool Equals(object obj)
    {
      return obj is EuroStatTable table 
      && tableCode == table.tableCode
      && filters == table.filters;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(tableCode);
    }

    public override string ToString()
      {
            return tableCode + " - " + filters;
      }
  }
}
