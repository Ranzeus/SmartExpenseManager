namespace SmartExpenseManager.Api.Contracts.Expenses;

public sealed record CreateExpenseRequest(
    decimal Amount,
    string Currency,
    DateTime Date,
    Guid CategoryId,
    Guid LedgerAccountId,
    Guid UserId,
    string? Description
);
