using System.Data;
using Domain.Aggregates.Accounts;
using Domain.Aggregates.PaymentProviders;
using Domain.Aggregates.Transfers;
using Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence;

public class BankingDbContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    
    protected BankingDbContext(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return (await Database.BeginTransactionAsync(IsolationLevel.Serializable, cancellationToken)).GetDbTransaction();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this);
        return await base.SaveChangesAsync(cancellationToken);
    }
}