﻿using AskMe.UseCases.Common.Dtos.UserProfile;
using AskMe.UseCases.UserProfiles.GetUserProfileById;
using AskMe.Web.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskMe.Web.Controllers;

[Route("api/profile/")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly IMediator mediator;

    public UserProfileController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get user profile by user id.
    /// </summary>
    /// <param name="id">User id.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>Post.</returns>
    [ProducesResponseType(typeof(UserProfileDto), 200)]
    [ProducesResponseType(400)]
    [HttpGet("{id}")]
    [Authorize(Roles = ExistingRoles.User)]
    public async Task<UserProfileDto> GetUserProfileById(Guid id, CancellationToken cancellationToken)
    {
        var command = new GetUserProfileByIdCommand(id);
        return await mediator.Send(command, cancellationToken);
    }
}
