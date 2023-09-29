namespace Ticket360.Application.Identity.Users;

public class UserListFilter : PaginationFilter
{
    public bool? IsActive { get; set; }
}