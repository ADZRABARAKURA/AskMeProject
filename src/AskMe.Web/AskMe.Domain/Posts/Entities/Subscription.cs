namespace AskMe.Domain.Posts.Entities;

/// <summary>
/// Subscription.
/// </summary>
public class Subscription
{
    /// <summary>
    /// Subscription Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Subscription title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// For which user this subscription is given        
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Is subscription still available for users to buy.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Date when subscription was created.
    /// </summary>
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Subscription last edition date.
    /// </summary>
    public DateTime? EditDate { get; set; }

    /// <summary>
    /// A description why the user might want to take this subscription.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Child subscriptions.
    /// </summary>
    public IEnumerable<Subscription> ChildSubscriptions;

    /// <summary>
    /// Subscription price.
    /// </summary>
    public SubscriptionPrice Price { get; set; }
}
