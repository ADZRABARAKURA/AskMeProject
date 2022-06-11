using AskMe.UseCases.Common.Dtos.Post;
using AskMe.UseCases.Common.Dtos.UserProfiles;
using AskMe.UseCases.Goals.CreateGoal;
using AskMe.UseCases.Goals.DeleteGoal;
using AskMe.UseCases.Goals.GetGoalsByUserId;
using AskMe.UseCases.User.GetCurrentUserProfile;
using AskMe.UseCases.UserProfiles .EditUserProfile;
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
    /// <returns>User profile.</returns>
    [ProducesResponseType(typeof(UserProfileDto), 200)]
    [ProducesResponseType(400)]
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<UserProfileDto> GetUserProfileById([FromRoute]  Guid id, CancellationToken cancellationToken)
    {
        var command = new GetUserProfileByIdCommand(id);
        return await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Get goals by user id.
    /// </summary>
    /// <param name="id">User id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Goals of user.</returns>
    [ProducesResponseType(typeof(IEnumerable<GoalDto>), 200)]
    [ProducesResponseType(400)]
    [AllowAnonymous]
    [HttpGet("{id}/goals")]
    public async Task<IEnumerable<GoalDto>> GetGoals([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new GetGoalsByUserIdCommand(id);
        return await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Create a goal.
    /// </summary>
    /// <param name="goal">Goal to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize(Roles = ExistingRoles.User)]
    [HttpPost("goals")]
    public async Task CreateGoal([FromForm] CreateGoalDto goal, CancellationToken cancellationToken)
    {
        var command = new CreateGoalCommand(goal);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Edit user profile.
    /// </summary>
    /// <param name="profile">Updated user profile.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)] 
    [Authorize(Roles = ExistingRoles.User)]
    [HttpPatch]
    public async Task EditProfile([FromForm] EditUserProfileDto profile, CancellationToken cancellationToken)
    {
        var command = new EditUserProfileCommand(profile);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Delete a goal.
    /// </summary>
    /// <param name="id">Id of goal to delete.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize(Roles = ExistingRoles.User)]
    [HttpDelete("goals/{id}")]
    public async Task DeleteGoal([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteGoalCommand(id);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Get currently logged in user profile.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User profile.</returns>
    [ProducesResponseType(typeof(UserProfileDto), 200)]
    [ProducesResponseType(400)]
    [HttpGet]
    [Authorize(Roles = ExistingRoles.User)]
    public async Task<UserProfileDto> GetMe(CancellationToken cancellationToken)
    {
        var command = new GetCurrentUserProfileCommand();
        return await mediator.Send(command, cancellationToken);
    }
}

