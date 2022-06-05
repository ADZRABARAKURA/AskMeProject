using AskMe.Domain.Posts.Entities;
using AskMe.Domain.Users.Entities;
using AskMe.Infrastructure.Abstractions.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AskMe.Infrastructure.DataAccess;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IAppDbContext
{
    public DbSet<Post> Posts { get; protected set; }

    public DbSet<UserProfile> Profiles { get; protected set; }

    public DbSet<Subscription> Subscriptions { get; protected set; }

    public DbSet<Publication> Publications { get; protected set; }

    public DbSet<Goal> Goals { get; protected set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}