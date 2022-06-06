using AskMe.Domain.Posts.Entities;

namespace AskMe.UseCases.Common.Dtos.Subscriptions;

/// <summary>
/// DTO for creating subscriptions.
/// </summary>
public record CreateSubscriptionDto
{
    /// <summary>
    /// Id of the user who will have access to the created subscription.
    /// </summary>
    public Guid UserId { get; init; }

    /// <inheritdoc cref="Subscription.Title"/>
    public string Title { get; init; }

    /// <inheritdoc cref="Subscription.Description"/>
    public string Description { get; init; }

    /// <inheritdoc cref="Subscription.Price"/>
    public SubscriptionPrice Price { get; init; }
}
