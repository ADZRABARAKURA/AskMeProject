using AskMe.Domain.Posts.Entities;
using AskMe.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace AskMe.Infrastructure.Abstractions.Interfaces;

public interface IAppDbContext : IDbContextWithSets, IDisposable
{
    DbSet<ApplicationRole> Roles { get; }
    DbSet<ApplicationUser> Users { get; }
    DbSet<Post> Posts { get; }

    DbSet<UserProfile> Profiles { get; }

    DbSet<Subscription> Subscriptions { get; }

    DbSet<UserSubscription> UserSubscriptions { get; }

    DbSet<Publication> Publications { get; }

    DbSet<Goal> Goals { get; }
}