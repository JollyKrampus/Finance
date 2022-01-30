using Finance.BlazorServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Finance.BlazorServer.Data;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
    {
    }

    public DbSet<RecurringTransaction>? RecurringTransactions { get; set; }
    public DbSet<Transaction>? Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>().Property(b => b.OccurredOn).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<RecurringTransaction>().Property(b => b.Frequency)
            .HasConversion(new EnumToStringConverter<RecurringTransaction.RecurringFrequency>());
    }
}