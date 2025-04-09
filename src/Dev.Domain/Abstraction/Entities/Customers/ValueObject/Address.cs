namespace Dev.Domain.Abstraction.Entities.Customers.ValueObject;

public record Address(string FirstLineAddress, string SecondLineAddress, string Postcode, string City, string Country);
