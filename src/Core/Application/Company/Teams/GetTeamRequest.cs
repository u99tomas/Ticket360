using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class GetTeamRequest : IRequest<TeamDto>
{
    public Guid Id { get; set; }

    public GetTeamRequest(Guid id) => Id = id;
}

public class TeamByIdSpec : Specification<Team, TeamDto>, ISingleResultSpecification
{
    public TeamByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetTeamRequestHandler : IRequestHandler<GetTeamRequest, TeamDto>
{
    private readonly IRepository<Team> _repository;
    private readonly IStringLocalizer _t;

    public GetTeamRequestHandler(IRepository<Team> repository, IStringLocalizer<GetTeamRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<TeamDto> Handle(GetTeamRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<Team, TeamDto>)new TeamByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Team {0} Not Found.", request.Id]);
}