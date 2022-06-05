namespace AskMe.UseCases.Common.Dtos.Post;

public record PostForDonaterDto
{
    /// <inheritdoc cref="Domain.Posts.Entities.Post.Id"/>
    public Guid Id { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.RecieverId"/>
    public string RecieverId { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.RecieverName"/>
    public string RecieverName { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.AuthorName"/>
    public string AuthorName { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.Value"/>
    public decimal Value { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.Text"/>
    public string Text { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.Currency"/>
    public string Currency { get; init; }

    /// <inheritdoc cref="Domain.Posts.Entities.Post.SentDate/>
    public DateTime SentDate { get; init; }
}
