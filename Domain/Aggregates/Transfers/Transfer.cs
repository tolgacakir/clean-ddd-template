using System.ComponentModel;
using System.Diagnostics;
using Domain.Aggregates.Shared;
using Domain.SeedWork;

namespace Domain.Aggregates.Transfers;

public class Transfer : AggregateRoot
{
    public Guid SourceAccountId { get; init; }
    public Guid DestinationAccountId { get; init; }
    public Amount Amount { get; init; }
    public TransferStatus Status { get; private set; }
    public DateTimeOffset InitiatedAt { get; private set; }
    public DateTimeOffset CompletedAt { get; private set; }
    
    public Transfer(Guid sourceAccountId, Guid destinationAccountId, Amount amount)
    {
        SourceAccountId = sourceAccountId;
        DestinationAccountId = destinationAccountId;
        Amount = amount;
        Status = TransferStatus.Created;
    }

    public void Initiate()
    {
        Status = TransferStatus.Initiated;
        InitiatedAt = DateTimeOffset.UtcNow;
    }

    public void Complete()
    {
        Status = TransferStatus.Completed;
        CompletedAt = DateTimeOffset.UtcNow;
    }

    public void Fail()
    {
        Status = TransferStatus.Failed;
    }

    public void Cancel()
    {
        Status = TransferStatus.Canceled;
    }
}