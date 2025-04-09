
namespace Dev.Domain.Abstraction.Entities.Customers.Events;

public sealed record CustomerCreatedDomainEvent(Guid CustomerId) : IDomainEvent;