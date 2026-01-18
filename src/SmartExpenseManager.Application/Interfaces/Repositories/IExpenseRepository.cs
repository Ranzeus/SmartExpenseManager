using SmartExpenseManager.Domain.Entities;

namespace SmartExpenseManager.Application.Interfaces.Repositories;

public interface IExpenseRepository
{
    Task AddAsync(Expense expense);
    Task<Expense?> GetByIdAsync(Guid id);
    Task UpdateAsync(Expense expense);
}
