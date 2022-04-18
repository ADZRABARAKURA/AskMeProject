using AskMe.UseCases.Common.Dtos.User;
using AskMe.UseCases.User.CreateUser;
using MediatR;
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

    [HttpPost("register")]
    public async Task Register([FromForm] UserDto user, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(user);
        await mediator.Send(command, cancellationToken);
    }
}
