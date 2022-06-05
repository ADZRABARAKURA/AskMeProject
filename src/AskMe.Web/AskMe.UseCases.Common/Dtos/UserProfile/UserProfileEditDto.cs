namespace AskMe.UseCases.Common.Dtos.UserProfile;

/// <summary>
/// User profile edit DTO.
/// </summary>
public record UserProfileEditDto
{
    /// <summary>
    /// Users passion.
    /// </summary>
    public string Passion { get; set; }

    /// <summary>
    /// Users description.
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Users references to content.
    /// </summary>
    public IEnumerable<string> References { get; init; }
}
