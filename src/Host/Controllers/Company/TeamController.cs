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
}
