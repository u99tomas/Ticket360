namespace Ticket360.Application.Company.Teams;

public class TeamDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
}