using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class GetTeamRequest : IRequest<TeamDto>
{
    public Guid Id { get; set; }

    public GetTeamRequest(Guid id) => Id = id;
}

public class GetTeamRequestHandler : IRequestHandler<GetTeamRequest, TeamDto>
{
    private readonly IRepository<Team> _repository;
    private readonly IStringLocalizer _t;

    public GetTeamRequestHandler(IRepository<Team> repository, IStringLocalizer<GetTeamRequestHandler> localizer)
    {
        _repository = repository;
        _t = localizer;
    }

    public async Task<TeamDto> Handle(GetTeamRequest request, CancellationToken cancellationToken)
    {
        var team = await _repository.FirstOrDefaultAsync(new TeamByIdSpec(request.Id), cancellationToken);

        if (team == null)
        {
            throw new NotFoundException(_t["Team {0} Not Found.", request.Id]);
        }

        return team;
    }
}


