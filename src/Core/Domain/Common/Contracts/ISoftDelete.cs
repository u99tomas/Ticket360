namespace Ticket360.Domain.Common.Contracts;

public interface ISoftDelete
{
    DateTime? DeletedOn { get; set; }
    Guid? DeletedBy { get; set; }
}