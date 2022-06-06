using AskMe.UseCases.Role.GiveRoleToUser;
using AskMe.Web.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskMe.Web.Controllers;

[Route("api/roles/")]
[ApiController]
public class RoleController
{
    private readonly IMediator mediator;

    public RoleController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Give role to user by user id.
    /// </summary>
    /// <param name="id">User id.</param>
    /// <param name="role">Application role.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [HttpPut]
    [Authorize(Roles = ExistingRoles.Admin)]
    public async Task GiveRole(Guid id, string role, CancellationToken cancellationToken)
    {
        var command = new GiveRoleToUserCommand(id, role);
        await mediator.Send(command, cancellationToken);
    }
}
