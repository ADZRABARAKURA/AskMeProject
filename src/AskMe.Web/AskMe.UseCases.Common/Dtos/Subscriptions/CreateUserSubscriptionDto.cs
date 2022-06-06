namespace AskMe.UseCases.Common.Dtos.Subscriptions;

/// <summary>
/// Entity to associate user and subscription.
/// </summary>
public record CreateUserSubscriptionDto
{
    /// <summary>
    /// Subscription Id;
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// How many months is the subscription
    /// </summary>
    public int MonthCount { get; init; }

    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; init; }
}
