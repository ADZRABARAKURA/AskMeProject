namespace AskMe.UseCases.Common.Dtos.User;

public record TokenModel
{
    /// <summary>
    /// Token.
    /// </summary>
    public string Token { get; init; }

    /// <summary>
    /// Expires in.
    /// </summary>
    public long ExpiresIn { get; init; }
}

