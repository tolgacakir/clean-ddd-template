using System.Data;
using Domain.Aggregates.Accounts;
using Domain.Aggregates.PaymentProviders;
using Domain.Aggregates.Transfers;

namespace Domain.SeedWork;

public interface IUnitOfWork
{
    Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}