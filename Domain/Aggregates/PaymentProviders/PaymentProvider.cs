using Domain.Aggregates.Shared;
using Domain.SeedWork;

namespace Domain.Aggregates.PaymentProviders;

public class PaymentProvider : AggregateRoot
{
    public string Code { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyCollection<Currency> SupportedCurrencies { get; private set; }
    public decimal TransactionFeeRate { get; private set; }
}