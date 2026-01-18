namespace SmartExpenseManager.Application.UseCases.Expenses.CreateExpense;

public sealed record CreateExpenseCommand(
    decimal Amount,
    string Currency,
    DateTime Date,
    Guid CategoryId,
    Guid LedgerAccountId,
    Guid UserId,
    string? Description
);
