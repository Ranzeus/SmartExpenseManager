using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartExpenseManager.Application.Interfaces.Repositories;
using SmartExpenseManager.Infrastructure.Persistence;
using SmartExpenseManager.Infrastructure.Repositories;

namespace SmartExpenseManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<SmartExpenseDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        //services.AddScoped<ILedgerEntryRepository, LedgerEntryRepository>();

        return services;
    }
}
