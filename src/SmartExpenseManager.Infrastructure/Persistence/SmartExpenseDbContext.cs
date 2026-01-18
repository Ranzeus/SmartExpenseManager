using Microsoft.EntityFrameworkCore;
using SmartExpenseManager.Domain.Entities;
using SmartExpenseManager.Domain.Enums;

namespace SmartExpenseManager.Infrastructure.Persistence;

public class SmartExpenseDbContext(DbContextOptions<SmartExpenseDbContext> options)
    : DbContext(options)
{
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<LedgerAccount> LedgerAccounts => Set<LedgerAccount>();
    public DbSet<LedgerEntry> LedgerEntries => Set<LedgerEntry>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmartExpenseDbContext).Assembly);

        // Seed Users
        var userId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001");
        var user = new User("John Doe", "john@example.com");
        SetId(user, userId);
        modelBuilder.Entity<User>().HasData(user);

        // Seed Categories
        var foodCategoryId = Guid.Parse("550e8400-e29b-41d4-a716-446655440010");
        var transportCategoryId = Guid.Parse("550e8400-e29b-41d4-a716-446655440011");
        var entertainmentCategoryId = Guid.Parse("550e8400-e29b-41d4-a716-446655440012");

        var foodCategory = new Category("Food", CategoryType.Normal);
        var transportCategory = new Category("Transport", CategoryType.Normal);
        var entertainmentCategory = new Category("Entertainment", CategoryType.Normal);

        SetId(foodCategory, foodCategoryId);
        SetId(transportCategory, transportCategoryId);
        SetId(entertainmentCategory, entertainmentCategoryId);

        modelBuilder.Entity<Category>().HasData(
            foodCategory,
            transportCategory,
            entertainmentCategory
        );

        // Seed LedgerAccounts
        var cashAccountId = Guid.Parse("550e8400-e29b-41d4-a716-446655440020");
        var bankAccountId = Guid.Parse("550e8400-e29b-41d4-a716-446655440021");

        var cashAccount = new LedgerAccount("Cash", AccountType.Cash);
        var bankAccount = new LedgerAccount("Bank Account", AccountType.BankAccount);

        SetId(cashAccount, cashAccountId);
        SetId(bankAccount, bankAccountId);

        modelBuilder.Entity<LedgerAccount>().HasData(
            cashAccount,
            bankAccount
        );
    }

    private static void SetId<T>(T entity, Guid id) where T : class
    {
        var idProperty = typeof(T).GetProperty("Id", 
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.IgnoreCase);
        
        if (idProperty != null && idProperty.CanWrite)
        {
            idProperty.SetValue(entity, id);
        }
    }
}
