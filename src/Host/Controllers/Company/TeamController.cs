using Ticket360.Application.Company.Teams;

namespace Ticket360.Host.Controllers.Company;

public class TeamController : VersionedApiController
{
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
}
