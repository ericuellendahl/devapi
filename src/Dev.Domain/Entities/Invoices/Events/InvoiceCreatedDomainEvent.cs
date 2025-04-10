using Dev.Domain.Abstraction;

namespace Dev.Domain.Entities.Invoices.Events;

public record InvoiceCreatedDomainEvent (Guid InvoiceId): IDomainEvent;
