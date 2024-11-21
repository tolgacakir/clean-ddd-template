using Domain.Aggregates.Transfers.DomainEvents;
using MediatR;

namespace Application.UseCases.Transfers.DomainEventHandlers;

public class TransferCanceledDomainEventHandler : INotificationHandler<TransferCanceledDomainEvent>
{
    public Task Handle(TransferCanceledDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}