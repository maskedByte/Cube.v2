namespace Engine.Exceptions;

public class ContextNotInitializedException : Exception
{
    public ContextNotInitializedException(string? message)
        : base(message)
    {
    }
}
