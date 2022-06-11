using AskMe.UseCases.Common.Dtos.Subscriptions;
using AskMe.UseCases.Subscriptions;
using AskMe.UseCases.Subscriptions.CreateSubscription;
using AskMe.UseCases.Subscriptions.DeleteSubscription;
using AskMe.UseCases.Subscriptions.ExtendSubscription;
using AskMe.UseCases.Subscriptions.GetSubscriptionsOfUser;
using AskMe.UseCases.Subscriptions.SubscribeUser;
using AskMe.Web.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskMe.Web.Controllers;

[Route("api/subscription/")]
[ApiController]
public class SubscriptionController : ControllerBase
{
    private readonly IMediator mediator;

    public SubscriptionController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get subscriptions by user id.
    /// </summary>
    /// <param name="id">User id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of subscriptions.</returns>
    [ProducesResponseType(typeof(IEnumerable<SubscriptionDto>), 200)]
    [ProducesResponseType(400)]
    [HttpGet("user/{id}")]
    [AllowAnonymous]
    public async Task<IEnumerable<SubscriptionDto>> GetSubscriptions([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new GetSubscriptionsByUserIdCommand(id);
        return await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Create new subscription.
    /// </summary>
    /// <param name="subscription">Subscription to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [Authorize(Roles = ExistingRoles.Streamer)]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [HttpPost]
    public async Task CreateSubscription([FromForm] CreateSubscriptionDto subscription, CancellationToken cancellationToken)
    {
        var command = new CreateSubscriptionCommand(subscription);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Delete subscription by it's id.
    /// </summary>
    /// <param name="id">Subscription id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize(Roles = ExistingRoles.Streamer)]
    [HttpDelete("{id}")]
    public async Task DeleteSubscription([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteSubscriptionCommand(id);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Subscribe.
    /// </summary>
    /// <param name="userSubscription">User subscription DTO.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize]
    [HttpPut("subscribe")]
    public async Task Subscribe([FromForm] CreateUserSubscriptionDto userSubscription, CancellationToken cancellationToken)
    {
        var command = new SubscribeUserCommand(userSubscription);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Extend currently existing subscription.
    /// </summary>
    /// <param name="userSubscription">User subscription DTO.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize]
    [HttpPatch("subscribe")]
    public async Task ExtendSubscription([FromForm] ExtendUserSubscriptionDto userSubscription, CancellationToken cancellationToken)
    {
        var command = new ExtendSubscriptionCommand(userSubscription);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Get subscriptions of user.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of subscriptions.</returns>
    [ProducesResponseType(typeof(IEnumerable<UserSubscriptionDto>), 200)]
    [ProducesResponseType(400)]
    [Authorize]
    [HttpGet("my-subscriptions")]
    public async Task<IEnumerable<UserSubscriptionDto>> GetSubscriptionsOfUser(CancellationToken cancellationToken)
    {
        var command = new GetSubscriptionsOfUserCommand();
        return await mediator.Send(command, cancellationToken);
    }
}
