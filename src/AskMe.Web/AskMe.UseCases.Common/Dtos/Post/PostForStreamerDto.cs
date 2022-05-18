namespace AskMe.UseCases.Common.Dtos.Post;

/// <summary>
/// Post DTO.
/// </summary>
public record PostForStreamerDto
{
    /// <inheritdoc cref="Domain.Posts.Entities.Post.Id"/>
    public Guid Id { get; set; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.Value"/>
    public decimal Value { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.Text"/>
    public string Text { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.Currency"/>
    public string Currency { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.SentDate/>
    public DateTime SentDate { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.PaidDate"/>
    public DateTime? PaidDate { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.AuthorName"/>
    public string AuthorName { get; init; }
}
