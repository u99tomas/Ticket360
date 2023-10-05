namespace Ticket360.Domain.Company;

public class Team : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }

    public Team(string name)
    {
        Name = name;
    }
}

