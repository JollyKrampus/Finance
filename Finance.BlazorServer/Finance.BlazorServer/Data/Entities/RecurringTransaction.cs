namespace Finance.BlazorServer.Data.Entities;

public class RecurringTransaction : TransactionBase
{
    public enum RecurringFrequency
    {
        Weekly,
        Monthly,
        Annually
    }

    //todo: figure frequency out how to store frequency in db
    public RecurringFrequency Frequency { get; set; }
    public List<Transaction>? Transactions { get; set; }
}