﻿using Ticket360.Application.Company.Teams;

namespace Ticket360.Host.Controllers.Company;

public class TeamController : VersionedApiController
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
}
