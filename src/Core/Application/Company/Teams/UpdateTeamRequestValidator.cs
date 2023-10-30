using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class UpdateTeamRequestValidator : CustomValidator<UpdateTeamRequest>
{
    public UpdateTeamRequestValidator(IRepository<Team> repository, IStringLocalizer<UpdateTeamRequestValidator> T) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (team, name, ct) =>
                await repository.FirstOrDefaultAsync(new TeamByNameSpec(name), ct)
                    is not Team existingTeam || existingTeam.Id == team.Id)
            .WithMessage((_, name) => T["Team {0} already Exists.", name]);
}