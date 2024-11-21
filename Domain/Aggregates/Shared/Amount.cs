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

    public Amount Sum(Amount amountToSum)
    {
        ThrowIfCurrencyIsNotEqual(amountToSum.Currency);
        
        var sum = AbsoluteAmount + amountToSum.AbsoluteAmount;
        return new Amount(sum, Currency);
    }

    public bool GreaterThanEqual(Amount amountToCompare)
    {
        ThrowIfCurrencyIsNotEqual(amountToCompare.Currency);
        return AbsoluteAmount >= amountToCompare.AbsoluteAmount;
    }

    public Amount Negative()
    {
        var negativeAmount = AbsoluteAmount * -1;
        return new Amount(negativeAmount, Currency);
    }

    public static Amount Zero(Currency currency)
    {
        return new Amount(0, currency);
    }

    public static Amount ZeroTRY()
    {
        return Zero(Currency.TRY);
    }

    public static Amount CreateTRY(decimal amount)
    {
        return new Amount(amount, Currency.TRY);
    }

    public void ThrowIfCurrencyIsNotEqual(Currency currencyToCheck)
    {
        if (Currency != currencyToCheck)
        {
            throw new InvalidOperationException("Currencies are not equal");
        }
    }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return AbsoluteAmount;
        yield return Currency;
    }
}