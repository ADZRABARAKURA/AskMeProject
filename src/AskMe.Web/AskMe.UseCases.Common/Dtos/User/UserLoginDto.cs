namespace AskMe.UseCases.Common.Dtos.User;

/// <summary>
/// User login DTO.
/// </summary>
public record UserLoginDto
{
    /// <summary>
    /// User's identifier.
    /// </summary>
    public string Identifier { get; set; }

    /// <summary>
    /// User's password.
    /// </summary>
    public string Password { get; init; }
}
