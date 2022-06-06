namespace AskMe.Domain.Posts.Entities;

/// <summary>
/// Entity to associate user and subscription.
/// </summary>
public class UserSubscription
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Date of the user's first subscription
    /// </summary>
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Related subscription id.
    /// </summary>
    public Guid SubscriptionId { get; init; }

    /// <summary>
    /// Related subscription.
    /// </summary>
    public Subscription Subscription { get; init; }

    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Date when the subscription will expire.
    /// </summary>
    public DateTime ExpireAt { get; init; }
}
