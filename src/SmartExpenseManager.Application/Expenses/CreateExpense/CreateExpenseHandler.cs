using SmartExpenseManager.Application.Interfaces.Repositories;
using SmartExpenseManager.Domain.Entities;
using SmartExpenseManager.Domain.ValueObjects;

namespace SmartExpenseManager.Application.UseCases.Expenses.CreateExpense;

public sealed class CreateExpenseHandler(
    IExpenseRepository expenseRepository,
    ICategoryRepository categoryRepository)
{
    public async Task<Guid> HandleAsync(CreateExpenseCommand command)
    {
        var category = await categoryRepository.GetByIdAsync(command.CategoryId)
            ?? throw new InvalidOperationException("Category not found.");

        var money = new Money(command.Amount, command.Currency);

        var expense = new Expense(
            money,
            command.Date,
            command.CategoryId,
            command.LedgerAccountId,
            command.UserId,
            command.Description
        );

        expense.Post();

        await expenseRepository.AddAsync(expense);

        return expense.Id;
    }
}
