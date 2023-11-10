using Ticket360.Application.Company.Teams;

namespace Ticket360.Host.Controllers.Company;

public class TeamsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Teams)]
    [OpenApiOperation("Search teams using available filters.", "")]
    public Task<PaginationResponse<TeamDto>> SearchAsync(SearchTeamsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Teams)]
    [OpenApiOperation("Create a new team.", "")]
    public Task<Guid> CreateAsync(CreateTeamRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Teams)]
    [OpenApiOperation("Get team details.", "")]
    public Task<TeamDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetTeamRequest(id));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Teams)]
    [OpenApiOperation("Delete a team.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteTeamRequest(id));
    }
    
    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Teams)]
    [OpenApiOperation("Update a team.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateTeamRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }
}
