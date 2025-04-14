using Dev.Domain.Entities.Invoices;
using Dev.Domain.Entities.Invoices.ValueObjects;
using Dev.Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Infrastructure.Configurations
{
    public class InvoceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(invoice => invoice.PoNumber)
                .HasConversion(poNumber => poNumber.Value, value => new PoNumber(value))
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(invoice => invoice.TotalBalance)
                .HasConversion(totalBalance => totalBalance.Value, value => new Money(value))
                .IsRequired()
                .HasPrecision(18, 2);

            builder.HasMany(invoice => invoice.PurchasedProducts)
                .WithOne(invoiceLine => invoiceLine.Invoice)
                .HasForeignKey(invoiceLine => invoiceLine.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}