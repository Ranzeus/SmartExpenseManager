using Microsoft.Extensions.DependencyInjection;
using SmartExpenseManager.Application.UseCases.Expenses.CreateExpense;

namespace SmartExpenseManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<CreateExpenseHandler>();

        return services;
    }
}
