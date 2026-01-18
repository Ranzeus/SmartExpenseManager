using SmartExpenseManager.Application.Interfaces.Repositories;
using SmartExpenseManager.Domain.Entities;
using SmartExpenseManager.Infrastructure.Persistence;

namespace SmartExpenseManager.Infrastructure.Repositories;

public class ExpenseRepository(SmartExpenseDbContext context)
    : IExpenseRepository
{
    public async Task AddAsync(Expense expense)
    {
        await context.Expenses.AddAsync(expense);
        await context.SaveChangesAsync();
    }

    public async Task<Expense?> GetByIdAsync(Guid id)
    {
        return await context.Expenses.FindAsync(id);
    }

    public async Task UpdateAsync(Expense expense)
    {
        context.Expenses.Update(expense);
        await context.SaveChangesAsync();
    }
}
