using Dev.Domain.Abstraction.Entities.Customers.DTOs;
using Dev.Domain.Abstraction.Entities.Customers.Events;
using Dev.Domain.Abstraction.Entities.Customers.ValueObject;
using Dev.Domain.Abstraction.Entities.Invoices;
using Dev.Domain.Abstraction.Entities.Shared;

namespace Dev.Domain.Abstraction.Entities.Customers;

public sealed class Customer : BaseEntity
{
    private Customer(Title title, Address address, Money balance)
    {
        Title = title;
        Address = address;
        Balance = balance;
    }

    private Customer() { }

    public Title Title { get; private set; }
    public Address Address { get; private set; }
    public Money Balance { get; private set; }

    public ICollection<Invoice> Invoices { get; private set; }

    public static Customer Create(CreateCustomerDto request)
    {
        var customer = new Customer(
            new Title(request.Title),
            new Address(request.FirstLineAddress, request.SecondLineAddress, request.Postcode, request.City, request.Country),
            new Money(0)
        );

        customer.RaiseDomainEvent(new CustomerCreatedDomainEvent(customer.Id));

        return customer;
    }

    public void Update(UpdateCustomerDto request)
    {
        Title = new Title(request.Title);
        Address = new Address(request.FirstLineAddress, request.SecondLineAddress, request.Postcode, request.City, request.Country);
    }
}