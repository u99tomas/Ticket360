using Finbuckle.MultiTenant.EntityFrameworkCore;
using Ticket360.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticket360.Infrastructure.Persistence.Configuration;

public class BrandConfig : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
    }
}

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(1024);

        builder
            .Property(p => p.ImagePath)
                .HasMaxLength(2048);
    }
}