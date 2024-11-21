using Domain.SeedWork;

namespace Domain.Aggregates.Shared;

public sealed class Amount : ValueObject
{
    public decimal AbsoluteAmount { get; init; }
    public Currency Currency { get; init; }

    public Amount(decimal amount, Currency currency)
    {
        AbsoluteAmount = amount;
        Currency = currency;
    }

    public static Amount Zero()
    {
        return new Amount(0, Currency.TRY);
    }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return AbsoluteAmount;
        yield return Currency;
    }
}