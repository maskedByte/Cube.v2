namespace Engine.Exceptions;

internal sealed class ComponentNotFoundException : Exception
{
    public ComponentNotFoundException()
    {
    }

    public ComponentNotFoundException(string? message)
        : base(message)
    {
    }

    public ComponentNotFoundException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
