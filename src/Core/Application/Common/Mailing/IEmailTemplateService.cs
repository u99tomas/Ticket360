namespace Ticket360.Application.Common.Mailing;

public interface IEmailTemplateService : ITransientService
{
    string GenerateEmailTemplate<T>(string templateName, T mailTemplateModel);
}