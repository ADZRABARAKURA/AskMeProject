namespace AskMe.UseCases.Common.Dtos.Post;

/// <summary>
/// Create publication DTO.
/// </summary>
public class CreatePublicationDto
{
    /// <summary>
    /// Publication header.
    /// </summary>
    public string Header { get; init; }

    /// <summary>
    /// Publication content.
    /// </summary>
    public string Content { get; init; }

    /// <summary>
    /// Related user id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Related subscription id.
    /// </summary>
    public Guid? SubscriptionId { get; init; }
}
