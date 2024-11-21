using Domain.Aggregates.Shared;
using Domain.SeedWork;

namespace Domain.Aggregates.Accounts;

public class Account : AggregateRoot
{
    public Guid OwnerId { get; init; }
    public Amount Balance { get; private set; }
    public AccountStatus Status { get; private set; }

    public Currency Currency => Balance.Currency;
    public decimal AbsoluteAmount => Balance.AbsoluteAmount;

    public Account(Guid ownerId, Currency currency)
    {
        Id = Guid.NewGuid();
        OwnerId = ownerId;
        Balance = Amount.Zero(currency);
        Status = AccountStatus.Passive;
    }
    
    public void Deposit(Amount amount)
    {
        if (amount.AbsoluteAmount < 0)
        {
            throw new InvalidOperationException("Cannot deposit negative amount");
        }
        
        Balance = Balance.Sum(amount);
    }

    public void Withdraw(Amount amount)
    {
        if (!CanWithdraw(amount))
        {
            throw new InvalidOperationException("Cannot withdraw negative amount");
        }
        
        var amountToWithdraw = amount.Negative();

        Balance = Balance.Sum(amount);
        
        if (Balance.AbsoluteAmount < 0)
        {
            throw new InvalidOperationException("Not enough.");
        }
    }

    public bool CanWithdraw(Amount amount)
    {
        return Balance.GreaterThanEqual(amount);
    }
}