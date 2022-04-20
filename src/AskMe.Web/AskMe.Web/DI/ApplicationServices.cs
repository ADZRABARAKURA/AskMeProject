using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.Infrastructure.DataAccess;
using AskMe.Web.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskMe.Web.DI;

internal static class ApplicationServices
{
    public static void Register(IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IJsonHelper, SystemTextJsonHelper>();
        services.AddScoped<IAppDbContext, AppDbContext>();
        services.AddScoped<ILoggedUserAccessor, LoggedUserAccessor>();
    }
}

