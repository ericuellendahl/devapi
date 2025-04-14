using Dev.Domain.Entities.InvoiceItems;
using Dev.Domain.Entities.InvoiceItems.ValueObjects;
using Dev.Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Infrastructure.Configurations
{
    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.Property(item => item.SellPrice)
                .HasConversion(sellPrice => sellPrice.Value, value => new Money(value))
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(item => item.Quantity)
                .HasConversion(quantity => quantity.Value, value => new Quantity(value))
                .IsRequired();

            builder.Property(item => item.TotalPrice)
            .HasConversion(totalPrice => totalPrice.Value, value => new Money(value))
            .IsRequired()
            .HasPrecision(18, 2);

            builder.Property(item => item.RowVersion)
                .IsRowVersion();

        }
    }
}