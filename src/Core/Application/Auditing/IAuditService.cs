namespace Ticket360.Application.Auditing;

public interface IAuditService : ITransientService
{
    Task<List<AuditDto>> GetUserTrailsAsync(Guid userId);
}