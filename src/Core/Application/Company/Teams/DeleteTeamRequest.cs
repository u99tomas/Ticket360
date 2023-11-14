using Ticket360.Domain.Common.Events;
using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class DeleteTeamRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public DeleteTeamRequest(Guid id) => Id = id;
}

public class DeleteTeamRequestHandler : IRequestHandler<DeleteTeamRequest, Guid>
{
    private readonly IRepository<Team> _repository;
    private readonly IStringLocalizer _t;

    public DeleteTeamRequestHandler(IRepository<Team> repository, IStringLocalizer<DeleteTeamRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeleteTeamRequest request, CancellationToken cancellationToken)
    {
        var team = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (team.DeletedOn != null)
        {
            var errorMessage = _t["Team {0} has already been deleted."];
            throw new NotFoundException(string.Format(errorMessage, request.Id));
        }

        team.DomainEvents.Add(EntityDeletedEvent.WithEntity(team));
        await _repository.DeleteAsync(team, cancellationToken);
        return request.Id;

    }
}