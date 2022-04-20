namespace AskMe.UseCases.Common.Dtos.Post;

public record PostDto
{
    public Guid UserId { get; init; }
    public decimal Value { get; init; }
    public string Text { get; init; }
    public string Currency { get; init; }
    public string AuthorName { get; init; }
}
