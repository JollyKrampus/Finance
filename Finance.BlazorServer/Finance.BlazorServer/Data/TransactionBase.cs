namespace Finance.BlazorServer.Data;

public abstract class TransactionBase
{
    public int Id { get; set; }
    public string? Payee { get; set; }
    public string? Category { get; set; }
    public string? Memo { get; set; }
    public decimal Outflow { get; set; }
    public decimal Inflow { get; set; }
}