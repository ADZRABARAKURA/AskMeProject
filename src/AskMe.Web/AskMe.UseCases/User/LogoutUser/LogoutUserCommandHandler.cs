using AskMe.Domain.Users.Entities;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.User.LogoutUser;

internal class LogoutUserCommandHandler : AsyncRequestHandler<LogoutUserCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;

    public LogoutUserCommandHandler(
        ILoggedUserAccessor loggedUserAccessor, 
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    protected override async Task Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = loggedUserAccessor.GetCurrentUserId();
        var user = await userManager.Users
            .Where(user => user.Id == currentUserId)
            .FirstOrDefaultAsync(cancellationToken);
        if (user is null)
        {
            return;
        }
        await signInManager.SignOutAsync();
    }
}
