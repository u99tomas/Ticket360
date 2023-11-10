namespace Ticket360.Domain.Company;

public class Team : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }

    public Team(string name)
    {
        Name = name;
    }

    public Team Update(string? name)
    {
        if (name is null || Name.Equals(name)) return this;
        Name = name;
        return this;
    }
}
