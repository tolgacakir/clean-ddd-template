using Domain.Aggregates.Transfers.DomainEvents;
using MediatR;

namespace Application.UseCases.Transfers.DomainEventHandlers;

public class TransferInitiatedDomainEventHandler : INotificationHandler<TransferInitiatedDomainEvent>
{
    public Task Handle(TransferInitiatedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}