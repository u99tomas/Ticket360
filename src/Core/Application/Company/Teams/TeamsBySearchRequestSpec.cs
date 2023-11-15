using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class TeamsBySearchRequestSpec : EntitiesByBaseFilterSpec<Team, TeamDto>
{
    public TeamsBySearchRequestSpec(SearchTeamsRequest request)
        : base(request) =>
        Query.Where(team => team.DeletedOn == null).OrderBy(c => c.Name, !request.HasOrderBy());
}