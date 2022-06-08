using AskMe.UseCases.Common.Dtos.User;
using AskMe.UseCases.User.CreateUser;
using AskMe.UseCases.User.LoginUser;
using AskMe.UseCases.User.LogoutUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskMe.Web.Controllers;

[Route("api/auth/")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator mediator;

    public AuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Logout.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize]
    [HttpPost("logout")]
    public async Task Logout(CancellationToken cancellationToken)
    {
        var command = new LogoutUserCommand();
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Register a new user.
    /// </summary>
    /// <param name="user">User DTO</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task Register([FromForm] UserDto user, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(user);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Authenticate user.
    /// </summary>
    /// <param name="user">User login DTO.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Token and User id.</returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<SuccessfulLoginDto> Login([FromForm] UserLoginDto user, CancellationToken cancellationToken)
    {
        var command = new LoginUserCommand(user);
        return await mediator.Send(command, cancellationToken);
    }
}
