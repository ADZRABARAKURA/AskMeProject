using Microsoft.OpenApi.Models;

namespace AskMe.Web.Web;

public class SwaggerSecurityRequirement
{
    public static OpenApiSecurityRequirement GetSecurityRequrement()
    {
        return new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        };
    }
}
