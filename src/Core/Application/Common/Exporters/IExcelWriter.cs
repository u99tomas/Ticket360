namespace Ticket360.Application.Common.Exporters;

public interface IExcelWriter : ITransientService
{
    Stream WriteToStream<T>(IList<T> data);
}