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
    /// A description why the user might want to take this subscription.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Subscription price.
    /// </summary>
    public SubscriptionPrice Price { get; set; }
}
