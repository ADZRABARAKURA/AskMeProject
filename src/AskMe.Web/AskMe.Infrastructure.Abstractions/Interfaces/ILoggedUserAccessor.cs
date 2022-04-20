namespace AskMe.Infrastructure.Abstractions.Interfaces;

public interface ILoggedUserAccessor
{
    Guid? GetCurrentUserId();
}
