using AskMe.Infrastructure.Abstractions.Interfaces;

namespace AskMe.Web.Web;

public class LoggedUserAccessor : ILoggedUserAccessor
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public LoggedUserAccessor(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public Guid? GetCurrentUserId()
    {
        if (httpContextAccessor.HttpContext == null)
        {
            throw new InvalidOperationException("There is no active HTTP context specified.");
        }

        var userId = httpContextAccessor.HttpContext.User.GetCurrentUserId();
        return userId == default ? null : userId;
    }
}