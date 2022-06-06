namespace AskMe.DomainServices.Exceptions;

public class ServerErrorException : Exception
{
    public ServerErrorException(string? message) : base(message)
    {
    }
}
