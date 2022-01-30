using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.BlazorServer.Data.Entities;

public abstract class TransactionBase
{
    [Key] public int Id { get; set; }

    public string? Payee { get; set; }
    public string? Category { get; set; }
    public string? Memo { get; set; }

    [Column(TypeName = "decimal(18,2)")] public decimal? Outflow { get; set; }

    [Column(TypeName = "decimal(18,2)")] public decimal? Inflow { get; set; }
}