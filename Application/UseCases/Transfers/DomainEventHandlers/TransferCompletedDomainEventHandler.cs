using Domain.Aggregates.Transfers.DomainEvents;
using MediatR;

namespace Application.UseCases.Transfers.DomainEventHandlers;

public class TransferCompletedDomainEventHandler : INotificationHandler<TransferCompletedDomainEvent>
{
    public Task Handle(TransferCompletedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}