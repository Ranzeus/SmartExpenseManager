using Microsoft.AspNetCore.Mvc;
using SmartExpenseManager.Api.Contracts.Expenses;
using SmartExpenseManager.Application.UseCases.Expenses.CreateExpense;

namespace SmartExpenseManager.Api.Controllers;

[ApiController]
[Route("api/expenses")]
public sealed class ExpensesController(
    CreateExpenseHandler createExpenseHandler)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateExpenseRequest request)
    {
        var command = new CreateExpenseCommand(
            request.Amount,
            request.Currency,
            request.Date,
            request.CategoryId,
            request.LedgerAccountId,
            request.UserId,
            request.Description
        );

        var expenseId = await createExpenseHandler.HandleAsync(command);

        return CreatedAtAction(nameof(Create), new { id = expenseId }, null);
    }
}
