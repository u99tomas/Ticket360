using Finbuckle.MultiTenant.EntityFrameworkCore;
using Ticket360.Infrastructure.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticket360.Infrastructure.Persistence.Configuration;

public class AuditTrailConfig : IEntityTypeConfiguration<Trail>
{
    public void Configure(EntityTypeBuilder<Trail> builder) =>
        builder
            .ToTable("AuditTrails", SchemaNames.Auditing)
            .IsMultiTenant();
}