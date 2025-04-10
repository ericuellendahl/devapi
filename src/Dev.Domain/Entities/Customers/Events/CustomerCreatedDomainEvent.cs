
using Dev.Domain.Abstraction;

namespace Dev.Domain.Entities.Customers.Events;

public sealed record CustomerCreatedDomainEvent(Guid CustomerId) : IDomainEvent;