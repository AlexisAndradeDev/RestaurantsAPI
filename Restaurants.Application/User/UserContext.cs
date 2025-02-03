using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.User;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User
            ?? throw new InvalidOperationException("User context is not present.");

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(claim => claim.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(claim => claim.Type == ClaimTypes.Role)!.Select(claim => claim.Value);

        return new CurrentUser(userId, email, roles);
    }
}
