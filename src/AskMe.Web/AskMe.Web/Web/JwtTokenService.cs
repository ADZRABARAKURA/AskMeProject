using AskMe.Infrastructure.Abstractions.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AskMe.Web.Web;

internal class JwtTokenService : IAuthenticationTokenService
{
    private readonly TokenValidationParameters tokenValidationParameters;

    public JwtTokenService(IOptionsMonitor<JwtBearerOptions> jwtOptionsMonitor)
    {
        tokenValidationParameters = jwtOptionsMonitor.Get(JwtBearerDefaults.AuthenticationScheme)
            .TokenValidationParameters.Clone();
        tokenValidationParameters.ValidateLifetime = false;
    }

    public string GenerateToken(IEnumerable<Claim> claims, TimeSpan expirationTime)
    {
        var jwtSecurityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.Add(expirationTime),
            issuer: tokenValidationParameters.ValidIssuer,
            audience: tokenValidationParameters.ValidAudience,
            signingCredentials:
                new SigningCredentials(tokenValidationParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256)
        );
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }

    public IEnumerable<Claim> GetTokenClaims(string token)
    {
        var principal = new JwtSecurityTokenHandler()
            .ValidateToken(token, tokenValidationParameters, out SecurityToken _);
        return principal.Claims;
    }
}
