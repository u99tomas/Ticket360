namespace Ticket360.Application.Company.Teams;

using Domain.Company;

public class CreateTeamRequest : IRequest<Guid>
{
    public string Name { get; set; }
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


