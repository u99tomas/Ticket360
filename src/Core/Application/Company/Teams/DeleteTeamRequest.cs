using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class DeleteTeamRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public DeleteTeamRequest(Guid id) => Id = id;
}

public class DeleteTeamRequestHandler : IRequestHandler<DeleteTeamRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Team> _teamRepo;
    private readonly IStringLocalizer _t;

    public DeleteTeamRequestHandler(IRepositoryWithEvents<Team> teamRepo, IStringLocalizer<DeleteTeamRequestHandler> localizer) =>
        (_teamRepo, _t) = (teamRepo, localizer);

    public async Task<Guid> Handle(DeleteTeamRequest request, CancellationToken cancellationToken)
    {
        var team = await _teamRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = team ?? throw new NotFoundException(_t["Team {0} Not Found."]);

        await _teamRepo.DeleteAsync(team, cancellationToken);

        return request.Id;
    }
}