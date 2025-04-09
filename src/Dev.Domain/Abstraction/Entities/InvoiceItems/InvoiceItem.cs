using Dev.Domain.Abstraction.Entities.InvoiceItems.ValueObjects;
using Dev.Domain.Abstraction.Entities.Invoices;
using Dev.Domain.Abstraction.Entities.Shared;

namespace Dev.Domain.Abstraction.Entities.InvoiceItems;

public sealed class InvoiceItem: BaseEntity
{
    private InvoiceItem(){}

    internal InvoiceItem(Guid id, Money sellPrice, Quantity quantity, Guid incoideId): base(id){
        SellPrice = sellPrice;
        Quantity = quantity;
        TotalPrice = new Money(sellPrice.Value * Quantity.Value);
        InvoiceId = incoideId;
    }

    public Money SellPrice { get; private set; }
    public Quantity Quantity { get; private set; }
    public Money TotalPrice { get; private set; }
    public Guid InvoiceId { get; private set; }
    public Invoice Invoice { get; private set; } 

}