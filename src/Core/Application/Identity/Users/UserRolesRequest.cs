namespace Ticket360.Application.Identity.Users;

public class UserRolesRequest
{
    public List<UserRoleDto> UserRoles { get; set; } = new();
}