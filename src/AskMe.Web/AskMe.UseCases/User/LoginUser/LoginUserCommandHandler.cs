using AskMe.Domain.Users.Entities;
using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AskMe.UseCases.User.LoginUser;

internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, SuccessfulLoginDto>
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IAuthenticationTokenService authenticationService;

    public LoginUserCommandHandler(
        UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager,
        IAuthenticationTokenService authenticationService)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.authenticationService = authenticationService;
    }

    public async Task<SuccessfulLoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
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

        // Combine refresh token with user id.
        var principal = await signInManager.CreateUserPrincipalAsync(user);

        return new SuccessfulLoginDto
        {
            UserId = user.Id,
            Token = TokenModelGenerator.Generate(authenticationService, principal.Claims)
        };
    }
}
