namespace AskMe.UseCases.Common.Dtos.User;

/// <summary>
/// DTO to display short information about user 
/// in search terms.
/// </summary>
public record SearchUserDto
{
    /// <summary>
    /// User id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// User's nickname.
    /// </summary>
    public string Name { get; init; }
}
