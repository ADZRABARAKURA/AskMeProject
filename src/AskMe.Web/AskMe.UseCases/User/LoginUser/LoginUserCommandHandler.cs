using AskMe.Domain.Users.Entities;
using AskMe.DomainServices.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AskMe.UseCases.User.LoginUser;

internal class LoginUserCommandHandler : AsyncRequestHandler<LoginUserCommand>
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;

    public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    protected override async Task Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.User.Identifier);
        if (user is null)
        {
            user = await userManager.FindByNameAsync(request.User.Identifier);
        }
        if (user is null)
        {
            throw new NotFoundException("Login/email is not correct.");
        }
        var loginResult = await signInManager.PasswordSignInAsync(
            user, 
            request.User.Password, 
            false, 
            false);
        if (!loginResult.Succeeded)
        {
            throw new ValidationException("Password is not correct.");
        }
    }
}
