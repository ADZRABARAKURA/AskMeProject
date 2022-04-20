namespace AskMe.UseCases.Common.Dtos.Post;

/// <summary>
/// A post to streamer.
/// </summary>
public record PostDto
{
    /// <inheritdoc cref="Domain.Posts.Entities.Post.UserId"/>
    public Guid UserId { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.Value"/>
    public decimal Value { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.Text"/>
    public string Text { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.Currency"/>
    public string Currency { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.AuthorName"/>
    public string AuthorName { get; init; }
}
