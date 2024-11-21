namespace Domain.SeedWork;

public abstract class Entity<T>
{
    public virtual T Id { get; protected set; } = default!;
    public virtual DateTimeOffset CreatedAt { get; protected set; } = DateTimeOffset.UtcNow;
    public virtual DateTimeOffset UpdatedAt { get; protected set; }
}