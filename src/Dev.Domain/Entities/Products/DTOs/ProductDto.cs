namespace Dev.Domain.Entities.Products.DTOs;

public abstract class BaseProductDto
{
    public string Title { get; set; }
    public decimal UnitPrice { get; set; }
}

public class CreateProductDto : BaseProductDto;
public class UpdateProductDto : BaseProductDto
{
    public Guid ProductId { get; set; }
}