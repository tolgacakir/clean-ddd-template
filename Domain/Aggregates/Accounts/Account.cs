using Domain.Aggregates.Shared;
using Domain.SeedWork;

namespace Domain.Aggregates.Accounts;

public class Account : AggregateRoot
{
    public Guid OwnerId { get; init; }
    public Amount Balance { get; private set; }
    public AccountStatus Status { get; private set; }

    public Account(Guid ownerId)
    {
        Id = Guid.NewGuid();
        OwnerId = ownerId;
        Balance = Amount.Zero();
        Status = AccountStatus.Passive;
    }
    
    public void Deposit(Amount amount)
    {
        
    }

    public void Withdraw(Amount amount)
    {
        
    }

    public void CanWithdraw(Amount amount)
    {
        
    }
}