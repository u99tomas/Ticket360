using Finbuckle.MultiTenant;
using Ticket360.Application.Common.Events;
using Ticket360.Application.Common.Interfaces;
using Ticket360.Domain.Catalog;
using Ticket360.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Ticket360.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(currentTenant, options, currentUser, serializer, dbSettings, events)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);
    }
}