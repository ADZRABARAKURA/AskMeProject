using AskMe.Domain.Posts.Entities;

namespace AskMe.Domain.Users.Entities;

/// <summary>
/// User profile information - can be only one for each user.
/// </summary>
public class UserProfile
{
    /// <summary>
    /// Profile id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Related user id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// User's description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Vocation of the user, what he does.
    /// </summary>
    public string? Passion { get; set; }

    /// <summary>
    /// References to user content separated by commas.
    /// </summary>
    public string? References { get; set; }

    /// <summary>
    /// User's goals.
    /// </summary>
    public List<Goal> Goals { get; init; } = new List<Goal>();
}
