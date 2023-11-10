using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class CreateTeamRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
}

public class CreateTeamHandler : IRequestHandler<CreateTeamRequest, Guid>
{
    private readonly IRepository<Team> _repository;

    public CreateTeamHandler(IRepository<Team> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateTeamRequest request, CancellationToken cancellationToken)
    {
        var team = new Team(request.Name);

        await _repository.AddAsync(team, cancellationToken);

        return team.Id;
    }
}


