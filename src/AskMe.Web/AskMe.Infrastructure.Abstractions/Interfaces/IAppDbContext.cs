using AskMe.Domain.Posts.Entities;
using AskMe.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace AskMe.Infrastructure.Abstractions.Interfaces;

public interface IAppDbContext : IDbContextWithSets, IDisposable
{
    DbSet<ApplicationRole> Roles { get; }
    DbSet<ApplicationUser> Users { get; }
    DbSet<Post> Posts { get; }
}