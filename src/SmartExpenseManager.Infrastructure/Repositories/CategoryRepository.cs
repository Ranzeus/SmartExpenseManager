using SmartExpenseManager.Application.Interfaces.Repositories;
using SmartExpenseManager.Domain.Entities;
using SmartExpenseManager.Infrastructure.Persistence;

namespace SmartExpenseManager.Infrastructure.Repositories;

public class CategoryRepository(SmartExpenseDbContext context) : ICategoryRepository
{
    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await context.Categories.FindAsync(id);
    }
}
