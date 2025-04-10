using Dev.Domain.Entities.InvoiceItems.DTOs;

namespace Dev.Domain.Entities.Invoices.DTOs;

public abstract class BaseInvoiceDto
{
    public string PoNumber { get; set; }
}

public class CreateInvoiceDto : BaseInvoiceDto
{
    public Guid CustomerId { get; set; }
    public ICollection<CreateInvoiceItemDto> PurchasedProducts { get; set; }
}

public class UpdateInvoiceDto : BaseInvoiceDto
{
    public Guid InvoiceId { get; set; }
}