using Domain.SeedWork;
using MediatR;

namespace Infrastructure.Persistence;

static class MediatorExtensions
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, BankingDbContext ctx)
    {
        var aggregateRoots = ctx.ChangeTracker
            .Entries<AggregateRoot>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = aggregateRoots
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        aggregateRoots.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}