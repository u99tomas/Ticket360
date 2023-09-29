namespace Ticket360.Application.Common.Mailing;

public interface IMailService : ITransientService
{
    Task SendAsync(MailRequest request, CancellationToken ct);
}