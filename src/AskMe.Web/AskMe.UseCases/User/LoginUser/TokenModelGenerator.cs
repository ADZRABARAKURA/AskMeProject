using AskMe.DomainServices;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.User;
using System.Security.Claims;

namespace AskMe.UseCases.User.LoginUser;

internal static class TokenModelGenerator
{
    public static TokenModel Generate(
        IAuthenticationTokenService authenticationTokenService,
        IEnumerable<Claim> claims)
    {
        var iatClaim = new Claim(AuthenticationConstants.IatClaimType, DateTime.UtcNow.Ticks.ToString(),
            ClaimValueTypes.Integer64);
        return new TokenModel
        {
            Token = authenticationTokenService.GenerateToken(
                claims.Union(new[] { iatClaim }),
                AuthenticationConstants.TokenExpirationTime),
            ExpiresIn = (int)AuthenticationConstants.TokenExpirationTime.TotalSeconds
        };
    }
}
