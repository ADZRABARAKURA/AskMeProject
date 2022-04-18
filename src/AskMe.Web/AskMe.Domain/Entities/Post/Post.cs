using AskMe.Domain.Entities.User;

namespace AskMe.Domain.Entities.Post;

public class Post
{
    public int Id { get; init; }

    public ApplicationUser User { get; init; }
    public int UserId { get; init; }
    public decimal Value { get; init; }
    public string Currency { get; init; }
    public DateTime? PaidDate { get; set; }
    public DateTime SentDate { get; init; }
    public string Text { get; init; }
    public string AuthorName { get; init; }
}
