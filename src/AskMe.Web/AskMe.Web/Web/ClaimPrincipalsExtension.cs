using System.Security.Claims;

namespace AskMe.Web.Web;

public static class ClaimPrincipalExtensions
{
    public static bool TryGetCurrentUserId(this ClaimsPrincipal principal, out Guid userId)
    {
        var currentUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!string.IsNullOrEmpty(currentUserId))
        {
            userId = Guid.Parse(currentUserId);
            return true;
        }
        userId = Guid.Empty;
        return false;
    }

    public static Guid GetCurrentUserId(this ClaimsPrincipal principal)
    {
        if (TryGetCurrentUserId(principal, out Guid userId))
        {
            return userId;
        }

        return Guid.Empty;
    }
}
