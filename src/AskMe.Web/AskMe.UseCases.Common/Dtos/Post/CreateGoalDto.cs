namespace AskMe.UseCases.Common.Dtos.Post;

/// <summary>
/// DTO for creating goals.
/// </summary>
public record CreateGoalDto
{
    /// <summary>
    /// Related user id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Goal title.
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// Value of a goal.
    /// </summary>
    public decimal Value { get; init; }
}
