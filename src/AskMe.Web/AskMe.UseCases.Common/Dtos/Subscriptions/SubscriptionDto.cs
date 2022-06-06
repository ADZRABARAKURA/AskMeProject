namespace AskMe.UseCases.Common.Dtos.Subscriptions;

/// <summary>
/// Subscription DTO.
/// </summary>
public record SubscriptionDto
{
    /// <inheritdoc cref="Domain.Posts.Entities.Subscription.Id"/>
    public Guid Id { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Subscription.UserId"/>
    public Guid UserId { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Subscription.Title"/>
    public string Title { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Subscription.Description"/>
    public string Description { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Subscription.CreationDate"/>
    public DateTime CreationDate { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Subscription.EditDate"/>
    public DateTime? EditDate { get; init; }
}
