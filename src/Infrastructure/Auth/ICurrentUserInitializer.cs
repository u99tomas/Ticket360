using System.Security.Claims;

namespace Ticket360.Infrastructure.Auth;

public interface ICurrentUserInitializer
{
    void SetCurrentUser(ClaimsPrincipal user);

    void SetCurrentUserId(string userId);
}