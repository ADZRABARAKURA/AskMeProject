using AskMe.Domain.Entities.User;
using AskMe.Infrastructure.DataAccess;
using Extensions.Hosting.AsyncInitialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AskMe.Web.StartUp;

/// <summary>
/// Contains database migration helper methods.
/// </summary>
internal sealed class DatabaseInitializer : IAsyncInitializer
{
    private readonly AppDbContext appDbContext;
    private readonly RoleManager<ApplicationRole> roleManager;

    /// <summary>
    /// Database initializer. Performs migration and data seed.
    /// </summary>
    /// <param name="appDbContext">Data context.</param>
    /// <param name="roleManager">Role manager.</param>
    /// <param name="roleService">Role service.</param>
    public DatabaseInitializer(AppDbContext appDbContext,
        RoleManager<ApplicationRole> roleManager)
    {
        this.appDbContext = appDbContext;
        this.roleManager = roleManager;
    }

    /// <inheritdoc />
    public async Task InitializeAsync()
    {
        await appDbContext.Database.EnsureCreatedAsync();
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
            await roleManager.SetRoleNameAsync(streamerRole, adminRoleName);
            await roleManager.UpdateNormalizedRoleNameAsync(streamerRole);
            await roleManager.CreateAsync(streamerRole);
        }
    }
}