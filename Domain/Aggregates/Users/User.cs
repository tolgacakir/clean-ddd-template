using Domain.SeedWork;

namespace Domain.Aggregates.Users;

public class User : AggregateRoot
{
    public string Username { get; init; }
}