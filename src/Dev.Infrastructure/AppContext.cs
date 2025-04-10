using Microsoft.EntityFrameworkCore;
using Dev.Domain.Entities.Customers;
using Dev.Domain.Entities.Products;
using Dev.Domain.Entities.Invoices;
using Dev.Domain.Entities.InvoiceItems;

namespace Dev.Infrastructure;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions options) : base(options) { }

    protected AppContext() { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}