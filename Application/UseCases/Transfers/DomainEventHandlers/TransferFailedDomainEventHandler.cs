using Domain.Aggregates.Transfers.DomainEvents;
using MediatR;

namespace Application.UseCases.Transfers.DomainEventHandlers;

public class TransferFailedDomainEventHandler : INotificationHandler<TransferFailedDomainEvent>
{
    public Task Handle(TransferFailedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}