using AskMe.Domain.Users.Entities;
using AskMe.Infrastructure.DataAccess;
using Extensions.Hosting.AsyncInitialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AskMe.Web.StartUp;

internal sealed class DatabaseInitializer : IAsyncInitializer
{
    private readonly AppDbContext appDbContext;
    private readonly RoleManager<ApplicationRole> roleManager;

    public DatabaseInitializer(AppDbContext appDbContext,
        RoleManager<ApplicationRole> roleManager)
    {
        this.appDbContext = appDbContext;
        this.roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        await appDbContext.Database.MigrateAsync();
        await AddDefaultRolesAsync();
        await UpdateRolesAsync();
    }

    private async Task UpdateRolesAsync()
    {
        var roles = await roleManager.Roles.ToListAsync();
    }

    private async Task AddDefaultRolesAsync()
    {
        var userRoleName = "User";
        if (await roleManager.FindByNameAsync(userRoleName) == null)
        {
            var userRole = new ApplicationRole();
            await roleManager.SetRoleNameAsync(userRole, userRoleName);
            await roleManager.CreateAsync(userRole);
        }

        var adminRoleName = "Admin";
        if (await roleManager.FindByNameAsync(adminRoleName) == null)
        {
            var adminRole = new ApplicationRole();
            await roleManager.SetRoleNameAsync(adminRole, adminRoleName);
            await roleManager.UpdateNormalizedRoleNameAsync(adminRole);
            await roleManager.CreateAsync(adminRole);
        }

        var streamerRoleName = "Streamer";
        if (await roleManager.FindByNameAsync(streamerRoleName) == null)
        {
            var streamerRole = new ApplicationRole();
            await roleManager.SetRoleNameAsync(streamerRole, streamerRoleName);
            await roleManager.UpdateNormalizedRoleNameAsync(streamerRole);
            await roleManager.CreateAsync(streamerRole);
        }
    }
}