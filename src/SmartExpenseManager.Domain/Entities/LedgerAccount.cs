using SmartExpenseManager.Domain.Enums;

namespace SmartExpenseManager.Domain.Entities;

public class LedgerAccount
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public AccountType AccountType { get; private set; }

    private LedgerAccount() { }

    public LedgerAccount(string name, AccountType accountType)
    {
        Id = Guid.NewGuid();
        Name = name;
        AccountType = accountType;
    }
}
