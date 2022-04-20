﻿using AskMe.Domain.Entities.Post;
using AskMe.Domain.Entities.User;
using AskMe.Infrastructure.Abstractions.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AskMe.Infrastructure.DataAccess;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IAppDbContext
{
    public DbSet<Post> Posts { get; protected set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}