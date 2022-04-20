using System.Security.Claims;

namespace AskMe.Web.Web;

public static class ClaimPrincipalExtensions
{
    public static bool TryGetCurrentUserId(this ClaimsPrincipal principal, out int userId)
    {
        var currentUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!string.IsNullOrEmpty(currentUserId))
        {
            userId = int.Parse(currentUserId);
            return true;
        }
        userId = -1;
        return false;
    }

    public static int GetCurrentUserId(this ClaimsPrincipal principal)
    {
        if (TryGetCurrentUserId(principal, out int userId))
        {
            return userId;
        }

        return default;
    }
}
