namespace AskMe.UseCases.Common.Dtos.Subscriptions;

/// <summary>
/// Entity to associate user and subscription.
/// </summary>
public record UserSubscriptionDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Subscription id.
    /// </summary>
    public Guid SubscriptionId { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.UserSubscription.CreationDate"/>
    public DateTime CreationDate { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.UserSubscription.ExpireAt"/>
    public DateTime ExpireAt { get; init; }

    /// <summary>
    /// Is subscription active or expired.
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Subscription title.
    /// </summary>
    public string SubscriptionTitle { get; init; }

    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; init; }
}
