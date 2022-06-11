namespace AskMe.UseCases.Common.Dtos.UserProfiles;

/// <summary>
/// User profile edit DTO.
/// </summary>
public record EditUserProfileDto
{
    /// <summary>
    /// Related user id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Users passion.
    /// </summary>
    public string? Passion { get; init; }

    /// <summary>
    /// Users description.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Users references to content.
    /// </summary>
    public IEnumerable<string>? References { get; init; }
}
