namespace SmartExpenseManager.Domain.ValueObjects;

public sealed class Money
{
    public decimal Value { get; }
    public string Currency { get; }

    public Money(decimal value, string currency)
    {
        if (value <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        Value = value;
        Currency = currency;
    }
}
