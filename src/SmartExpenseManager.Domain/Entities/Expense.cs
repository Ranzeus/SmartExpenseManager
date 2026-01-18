using SmartExpenseManager.Domain.Enums;
using SmartExpenseManager.Domain.ValueObjects;

namespace SmartExpenseManager.Domain.Entities;

public class Expense
{
    public Guid Id { get; private set; }
    public Money Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string? Description { get; private set; }
    public ExpenseStatus Status { get; private set; }

    public Guid CategoryId { get; private set; }
    public Guid LedgerAccountId { get; private set; }
    public Guid UserId { get; private set; }

    private Expense() { }

    public Expense(
        Money amount,
        DateTime date,
        Guid categoryId,
        Guid ledgerAccountId,
        Guid userId,
        string? description = null)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        Date = date;
        CategoryId = categoryId;
        LedgerAccountId = ledgerAccountId;
        UserId = userId;
        Description = description;
        Status = ExpenseStatus.Draft;
    }

    public void Post() => Status = ExpenseStatus.Posted;

    public bool RequiresLedgerEntry(Category category) =>
        Status == ExpenseStatus.Posted && category.GeneratesLedgerEntry();
}
