namespace Ticket360.Infrastructure.Persistence.Initialization;

public interface ICustomSeeder
{
    Task InitializeAsync(CancellationToken cancellationToken);
}