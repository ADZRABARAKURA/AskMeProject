namespace AskMe.Domain.Posts.Entities;

/// <summary>
/// Subscription price in USD.
/// </summary>
public enum SubscriptionPrice
{
    VeryCheap = 1,
    Cheap = 2,
    Reasonable = 5,
    Medium = 10,
    Expensive = 25,
    VeryExpensive = 50,
    Exclusive = 100
}
