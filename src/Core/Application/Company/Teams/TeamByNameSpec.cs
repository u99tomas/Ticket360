using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class TeamByNameSpec : Specification<Team>, ISingleResultSpecification
{
    public TeamByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}