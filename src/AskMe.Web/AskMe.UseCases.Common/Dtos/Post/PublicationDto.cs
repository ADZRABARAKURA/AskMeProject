namespace AskMe.UseCases.Common.Dtos.Post;

/// <summary>
/// Publication DTO for viewing the profile.
/// </summary>
public record PublicationDto
{
    /// <summary>
    /// Publication id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Publication description.
    /// </summary>
    public string Header { get; init; }

    /// <summary>
    /// Publication content.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// The name of the subscription that is required to view the publication
    /// </summary>
    public string? Subscription { get; init; }

    /// <summary>
    /// Is post available to current user.
    /// </summary>
    public bool IsAvailable { get; set; }
}
