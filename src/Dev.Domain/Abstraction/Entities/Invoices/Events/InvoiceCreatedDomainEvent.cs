namespace Dev.Domain.Abstraction.Entities.Invoices.Events;

public record InvoiceCreatedDomainEvent (Guid InvoiceId): IDomainEvent;
