
namespace Dev.Domain.Abstraction;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
    }

    protected BaseEntity(Guid id)
    => Id = id;


    private readonly List<IDomainEvent> _domainEvents = [];

    public Guid Id { get; init; }
    public byte[] RowVersion { get; set; }

    public IReadOnlyList<IDomainEvent> GetDomainEnvets()
    => _domainEvents.ToList();

    public void ClearDomainEvents()
    => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    => _domainEvents.Add(domainEvent);
    
}