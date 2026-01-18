using SmartExpenseManager.Domain.Enums;

namespace SmartExpenseManager.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public CategoryType CategoryType { get; private set; }

    private Category() { }

    public Category(string name, CategoryType categoryType)
    {
        Id = Guid.NewGuid();
        Name = name;
        CategoryType = categoryType;
    }

    public bool GeneratesLedgerEntry() =>
        CategoryType == CategoryType.Normal;
}
