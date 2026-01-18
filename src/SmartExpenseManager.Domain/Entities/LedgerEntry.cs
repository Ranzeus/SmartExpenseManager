using SmartExpenseManager.Domain.ValueObjects;

namespace SmartExpenseManager.Domain.Entities;

public class LedgerEntry
{
    public Guid Id { get; private set; }
    public Guid ExpenseId { get; private set; }
    public Guid LedgerAccountId { get; private set; }

    public Money Amount { get; private set; }
    public DateTime EntryDate { get; private set; }

    private LedgerEntry() { }

    public LedgerEntry(
        Guid expenseId,
        Guid ledgerAccountId,
        Money amount,
        DateTime entryDate)
    {
        Id = Guid.NewGuid();
        ExpenseId = expenseId;
        LedgerAccountId = ledgerAccountId;
        Amount = amount;
        EntryDate = entryDate;
    }
}