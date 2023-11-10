using Ticket360.Domain.Company;

namespace Ticket360.Application.Company.Teams;

public class CreateTeamRequestValidator : CustomValidator<CreateTeamRequest>
{
    public CreateTeamRequestValidator(IReadRepository<Team> teamRepo,IStringLocalizer<CreateTeamRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(64)
            .MustAsync(async (name, ct) => await teamRepo.FirstOrDefaultAsync(new TeamByNameSpec(name), ct) is null)
            .WithMessage((_, name) => T["Team {0} already Exists.", name]);
    }
}