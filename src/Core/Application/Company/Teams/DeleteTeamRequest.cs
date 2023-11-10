using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class DeleteTeamRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public DeleteTeamRequest(Guid id) => Id = id;
}

public class DeleteTeamRequestHandler : IRequestHandler<DeleteTeamRequest, Guid>
{
    private readonly IRepositoryWithEvents<Team> _repository;
    private readonly IStringLocalizer _t;

    public DeleteTeamRequestHandler(IRepositoryWithEvents<Team> repository, IStringLocalizer<DeleteTeamRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeleteTeamRequest request, CancellationToken cancellationToken)
    {
        var team = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = team ?? throw new NotFoundException(_t["Team {0} Not Found."]);

        await _repository.DeleteAsync(team, cancellationToken);

        return request.Id;
    }
}