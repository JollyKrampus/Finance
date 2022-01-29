using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.BlazorServer.Data
{
    public class Transaction : TransactionBase
    {
        public DateTime OccurredOn { get; set; }
        public int RecurringTransactionId { get; set; }
        [ForeignKey(nameof(RecurringTransactionId))]
        public RecurringTransaction? RecurringTransaction { get; set; }
    }
}
