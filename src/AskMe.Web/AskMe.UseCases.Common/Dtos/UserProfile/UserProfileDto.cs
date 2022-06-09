using AskMe.UseCases.Common.Dtos.Post;

namespace AskMe.UseCases.Common.Dtos.UserProfile;

/// <summary>
/// User profile DTO.
/// </summary>
public record UserProfileDto
{
    /// <summary>
    /// Id of related user.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Count of user subscribers.
    /// </summary>
    public int Subscribers { get; init; }

    /// <summary>
    /// Price for the cheapest subscription.
    /// </summary>
    public decimal CheapestSubscriptionPrice { get; init; }

    /// <summary>
    /// User profile description.
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// User passion.
    /// </summary>
    public string Passion { get; init; }
    
    /// <summary>
    /// References to user content.
    /// </summary>
    public IEnumerable<string> References { get; init; }

    /// <summary>
    /// Publications.
    /// </summary>
    public IEnumerable<PublicationDto> Publications { get; set; }
}
