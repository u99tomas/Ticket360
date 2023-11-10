using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class UpdateTeamRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
}

public class UpdateTeamRequestHandler : IRequestHandler<UpdateTeamRequest, Guid>
{
    private readonly IRepositoryWithEvents<Team> _repository;
    private readonly IStringLocalizer _t;

    public UpdateTeamRequestHandler(IRepositoryWithEvents<Team> repository, IStringLocalizer<UpdateTeamRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(UpdateTeamRequest request, CancellationToken cancellationToken)
    {
        var team = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = team
            ?? throw new NotFoundException(_t["Team {0} Not Found.", request.Id]);

        team.Update(request.Name);

        await _repository.UpdateAsync(team, cancellationToken);

        return request.Id;
    }
}