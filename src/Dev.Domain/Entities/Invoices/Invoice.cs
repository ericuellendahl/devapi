using Dev.Domain.Abstraction;
using Dev.Domain.Entities.Customers;
using Dev.Domain.Entities.InvoiceItems;
using Dev.Domain.Entities.InvoiceItems.ValueObjects;
using Dev.Domain.Entities.Invoices.DTOs;
using Dev.Domain.Entities.Invoices.Events;
using Dev.Domain.Entities.Invoices.ValueObjects;
using Dev.Domain.Entities.Products;
using Dev.Domain.Entities.Shared;

namespace Dev.Domain.Entities.Invoices;

public sealed class Invoice : BaseEntity
{
    private Invoice()
    { }

    private Invoice(Guid invoiceId, PoNumber poNumber, Guid customerId, ICollection<InvoiceItem> purchasedProducts, Money totalBalance) : base(invoiceId)
    {
        PoNumber = poNumber;
        CustomerId = customerId;
        PurchasedProducts = purchasedProducts;
        TotalBalance = totalBalance;
    }

    public PoNumber PoNumber { get; private set; }
    public Guid CustomerId { get; private set; }
    public Customer Customer { get; set; }
    public ICollection<InvoiceItem> PurchasedProducts { get; private set; }
    public Money TotalBalance { get; private set; }

    public static async Task<Invoice> Create(CreateInvoiceDto request, IUnitOfWork unitOfWork)
    {

        if (request.PurchasedProducts is null || request.PurchasedProducts.Count == 0)
        {
            throw new InvalidOperationException("Invoice must have at least one product");
        };

        var invoiceId = Guid.NewGuid();
        var purchasedProducts = new List<InvoiceItem>();


        foreach (var purchasedProduct in request.PurchasedProducts)
        {
            var product = await unitOfWork.Repository<Product>().GetByIdAsync(purchasedProduct.ProductId) ??
                          throw new ArgumentException($"Product with id {purchasedProduct.ProductId} not found");

            var invoiceItem = new InvoiceItem(Guid.NewGuid(), new Money(product.UniPrice.Value), new Quantity(purchasedProduct.Quantity), invoiceId);
            purchasedProducts.Add(invoiceItem);
        }

        var totalBalance = purchasedProducts.Sum(p => p.TotalPrice.Value);

        var invoice = new Invoice(invoiceId, new PoNumber(request.PoNumber), request.CustomerId, purchasedProducts, new Money(totalBalance));

        invoice.RaiseDomainEvent(new InvoiceCreatedDomainEvent(invoice.Id));

        return invoice;
    }

    public void Update(UpdateInvoiceDto request)
    {
        PoNumber = new PoNumber(request.PoNumber);
    }
}