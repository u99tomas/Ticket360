using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class TeamByIdSpec : Specification<Team, TeamDto>, ISingleResultSpecification
{
    public TeamByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}