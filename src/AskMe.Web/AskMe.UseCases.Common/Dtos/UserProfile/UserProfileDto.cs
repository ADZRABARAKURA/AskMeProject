using AskMe.UseCases.Common.Dtos.Post;

namespace AskMe.UseCases.Common.Dtos.UserProfiles;

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
    public int Subscribers { get; set; }

    /// <summary>
    /// Price for the cheapest subscription.
    /// </summary>
    public decimal CheapestSubscriptionPrice { get; set; }

    /// <summary>
    /// User profile description.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// User passion.
    /// </summary>
    public string? Passion { get; init; }
    
    /// <summary>
    /// References to user content.
    /// </summary>
    public IEnumerable<string>? References { get; init; }

    /// <summary>
    /// Publications.
    /// </summary>
    public IEnumerable<PublicationDto> Publications { get; set; }

    /// <summary>
    /// Goals.
    /// </summary>
    public IEnumerable<GoalDto> Goals { get; set; }
}
