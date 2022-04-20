namespace AskMe.UseCases.Common.Dtos.User;

public record UserDto
{
    /// <summary>
    /// Username.
    /// </summary>
    public string UserName { get; init; }

    /// <summary>
    /// User email.
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// User password.
    /// </summary>
    public string Password { get; init; }
}