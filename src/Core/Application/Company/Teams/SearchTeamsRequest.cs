using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class SearchTeamsRequest : PaginationFilter, IRequest<PaginationResponse<TeamDto>>
{
}

public class SearchTeamsRequestHandler : IRequestHandler<SearchTeamsRequest, PaginationResponse<TeamDto>>
{
    private readonly IReadRepository<Team> _repository;

    public SearchTeamsRequestHandler(IReadRepository<Team> repository) => _repository = repository;

    public async Task<PaginationResponse<TeamDto>> Handle(SearchTeamsRequest request, CancellationToken cancellationToken)
    {
        var spec = new TeamsBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}