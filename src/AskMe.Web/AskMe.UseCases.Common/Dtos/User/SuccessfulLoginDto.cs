namespace AskMe.UseCases.Common.Dtos.User;

/// <summary>
/// DTO to return a token upon successful authentication.
/// </summary>
public class SuccessfulLoginDto
{
    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// JWT token.
    /// </summary>
    public TokenModel Token { get; init; }
}
