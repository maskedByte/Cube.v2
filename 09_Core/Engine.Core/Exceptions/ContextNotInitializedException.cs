namespace Engine.Core.Exceptions;

public class ContextNotInitializedException : Exception
{
    public ContextNotInitializedException(string? message)
        : base(message)
    {
    }
}
