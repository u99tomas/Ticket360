using Finbuckle.MultiTenant.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket360.Domain.Company;

namespace Ticket360.Infrastructure.Persistence.Configuration;

public class TeamConfig : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(t => t.Name)
            .HasMaxLength(64);
    }
}