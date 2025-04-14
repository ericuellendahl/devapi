using Dev.Domain.Entities.Customers;
using Dev.Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsOne(customer => customer.Address, address =>
        {
            address.Property(address => address.FirstLineAddress).IsRequired().HasMaxLength(40);

            address.Property(address => address.SecondLineAddress).HasMaxLength(40);

            address.Property(address => address.Postcode).IsRequired().HasMaxLength(10);

            address.Property(address => address.City).IsRequired().HasMaxLength(20);

            address.Property(address => address.Country).IsRequired().HasMaxLength(20);
        });

        builder.Property(customer => customer.Title)
            .HasConversion(title => title.Value, value => new Title(value))
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(customer => customer.Balance)
            .HasConversion(balance => balance.Value, value => new Money(value))
            .IsRequired()
            .HasPrecision(18, 2);

        builder.HasMany(customer => customer.Invoices)
            .WithOne(invoice => invoice.Customer)
            .HasForeignKey(invoice => invoice.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(customer => customer.RowVersion)
            .IsRowVersion();

    }
}