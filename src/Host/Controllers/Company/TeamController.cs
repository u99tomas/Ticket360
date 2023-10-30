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
