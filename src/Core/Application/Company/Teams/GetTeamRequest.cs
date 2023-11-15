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
        var teamValidator = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (teamValidator.DeletedOn != null)
        {
            var errorMessage = _t["Team {0} does not exist or was deleted."];
            throw new NotFoundException(string.Format(errorMessage, request.Id));
        }

        return team;
    }
}


