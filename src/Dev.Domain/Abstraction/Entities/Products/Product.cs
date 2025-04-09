using Dev.Domain.Abstraction.Entities.Products.DTOs;
using Dev.Domain.Abstraction.Entities.Shared;

namespace Dev.Domain.Abstraction.Entities.Products;

public sealed class Product : BaseEntity
{
    private Product()
    { }

    private Product(Guid id, Title title, Money money) : base(id)
    {
        Description = title;
        UniPrice = money;
    }

    public Title Description { get; private set; }
    public Money UniPrice { get; private set; }

    public static Product Create(CreateProductDto request)
    => new(Guid.NewGuid(), new Title(request.Title), new Money(request.UnitPrice));

    public void Update(UpdateProductDto request)
    {
        Description = new Title(request.Title);
        UniPrice = new Money(request.UnitPrice);
    }
}



