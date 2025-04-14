using Dev.Domain.Entities.Products;
using Dev.Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Description)
                .HasConversion(description => description.Value, value => new Title(value))
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(product => product.UniPrice)
            .HasConversion(unitPrice => unitPrice.Value, value => new Money(value))
            .IsRequired()
            .HasPrecision(18, 2);
            
            builder.Property(product => product.RowVersion)
                .IsRowVersion();
        }
    }
}