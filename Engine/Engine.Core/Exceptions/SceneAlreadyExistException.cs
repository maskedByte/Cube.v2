using System.Runtime.Serialization;

namespace Engine.Exceptions;

public class SceneAlreadyExistException : Exception
{
    public SceneAlreadyExistException()
    {
    }

    public SceneAlreadyExistException(string? message)
        : base(message)
    {
    }

    public SceneAlreadyExistException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected SceneAlreadyExistException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
