namespace Finance.BlazorServer.Data;

public class RecurringTransaction : TransactionBase
{        
    public DateTime DueOn { get; set; }
    public List<Transaction>? Transactions { get; set; }
}