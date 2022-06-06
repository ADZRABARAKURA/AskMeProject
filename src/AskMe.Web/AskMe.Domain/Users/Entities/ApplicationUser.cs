using Microsoft.AspNetCore.Identity;

namespace AskMe.Domain.Users.Entities;

/// <summary>
/// Application user.
/// </summary>
public class ApplicationUser : IdentityUser<Guid> 
{
}