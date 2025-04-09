namespace Dev.Domain.Abstraction.Entities.Customers.DTOs;

public abstract class BaseCustomerDto
{
    public string Title { get; set; }
    public string FirstLineAddress { get; set; }
    public string SecondLineAddress { get; set; }
    public string Postcode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

public class CreateCustomerDto : BaseCustomerDto;
public class UpdateCustomerDto : BaseCustomerDto
{
    public Guid CustomerId { get; set; }

}