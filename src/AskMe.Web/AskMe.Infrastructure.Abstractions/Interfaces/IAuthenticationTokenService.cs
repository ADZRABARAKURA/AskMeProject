using System.Security.Claims;

namespace AskMe.Infrastructure.Abstractions.Interfaces;

public interface IAuthenticationTokenService
{
    string GenerateToken(IEnumerable<Claim> claims, TimeSpan expirationTime);
}
