using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AskMe.Web.Web;

internal class JwtOptionsSetup
{
    private readonly string secretKey;
    private readonly string issuer;

    public JwtOptionsSetup(string secretKey, string issuer)
    {
        this.secretKey = secretKey;
        this.issuer = issuer;
    }

    public void Setup(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
            ValidIssuer = issuer
        };
    }
}
