namespace AskMe.UseCases.Common.Dtos.Subscriptions;

/// <summary>
/// DTO to renew a user's subscription.
/// </summary>
public record ExtendUserSubscriptionDto
{
    /// <summary>
    /// User subscription Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Related user id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// How many months to renew the subscription.
    /// </summary>
    public int MonthCount { get; init; }
}
